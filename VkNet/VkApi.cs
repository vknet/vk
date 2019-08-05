// ReSharper disable once RedundantUsingDirective
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using VkNet.Abstractions;
using VkNet.Abstractions.Authorization;
using VkNet.Abstractions.Category;
using VkNet.Abstractions.Core;
using VkNet.Abstractions.Utils;
using VkNet.Categories;
using VkNet.Enums;
using VkNet.Exception;
using VkNet.Infrastructure;
using VkNet.Model;
using VkNet.Utils;
using VkNet.Utils.AntiCaptcha;
using VkNet.Utils.JsonConverter;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable EventNeverSubscribedTo.Global

namespace VkNet
{
	/// <summary>
	/// Служит для оповещения об истечении токена
	/// </summary>
	/// <param name="sender">
	/// Экземпляр API у которого истекло время токена
	/// </param>
	public delegate void VkApiDelegate(VkApi sender);

	/// <inheritdoc />
	/// <summary>
	/// API для работы с ВКонтакте.
	/// Выступает в качестве фабрики для различных категорий API (например, для работы
	/// с пользователями, группами и т.п.)
	/// </summary>
	public class VkApi : IVkApi
	{
		/// <summary>
		/// Параметры авторизации.
		/// </summary>
		private IApiAuthParams _ap;

		/// <summary>
		/// Таймер.
		/// </summary>
		private Timer _expireTimer;

		/// <summary>
		/// Сервис управления языком
		/// </summary>
		private ILanguageService _language;

		/// <summary>
		/// Логгер
		/// </summary>
		private ILogger<VkApi> _logger;

		/// <summary>
		/// JsonSerializer
		/// </summary>
		private JsonSerializer _jsonSerializer;

	#pragma warning disable S1104 // Fields should not have public accessibility
		/// <summary>
		/// Rest Client
		/// </summary>
		public IRestClient RestClient;
	#pragma warning restore S1104 // Fields should not have public accessibility

		/// <inheritdoc />
		public VkApi(ILogger<VkApi> logger, ICaptchaSolver captchaSolver = null, IAuthorizationFlow authorizationFlow = null)
		{
			var container = new ServiceCollection();

			if (logger != null)
			{
				container.TryAddSingleton(logger);
			}

			if (captchaSolver != null)
			{
				container.TryAddSingleton(captchaSolver);
			}

			if (authorizationFlow != null)
			{
				container.TryAddSingleton(authorizationFlow);
			}

			container.RegisterDefaultDependencies();

			IServiceProvider serviceProvider = container.BuildServiceProvider();

			Initialization(serviceProvider);
		}

		/// <inheritdoc />
		public VkApi(IServiceCollection serviceCollection = null)
		{
			var container = serviceCollection ?? new ServiceCollection();

			container.RegisterDefaultDependencies();

			IServiceProvider serviceProvider = container.BuildServiceProvider();

			Initialization(serviceProvider);
		}

		/// <summary>
		/// Токен для доступа к методам API
		/// </summary>
		private string AccessToken { get; set; }

		/// <inheritdoc />
		public IVkApiVersionManager VkApiVersion { get; set; }

		/// <inheritdoc />
		public event VkApiDelegate OnTokenExpires;

		/// <inheritdoc />
		[Obsolete("Нужно использовать AuthorizationFlow", false)]
		public IBrowser Browser { get; set; }

		/// <inheritdoc />
		public IAuthorizationFlow AuthorizationFlow { get; set; }

		/// <inheritdoc />
		public INeedValidationHandler NeedValidationHandler { get; set; }

		/// <inheritdoc />
		public bool IsAuthorized => !string.IsNullOrWhiteSpace(AccessToken);

		/// <inheritdoc />
		public string Token => AccessToken;

		/// <inheritdoc />
		public long? UserId { get; set; }

		/// <inheritdoc />
		public ICaptchaSolver CaptchaSolver { get; set; }

		/// <inheritdoc />
		public void SetLanguage(Language language)
		{
			_language.SetLanguage(language);
		}

		/// <inheritdoc />
		public Language? GetLanguage()
		{
			return _language.GetLanguage();
		}

		/// <inheritdoc />
		public void Authorize(IApiAuthParams @params)
		{
			AuthorizeAsync(@params).GetAwaiter().GetResult();
		}

		/// <inheritdoc />
		public void Authorize(ApiAuthParams @params)
		{
			Authorize((IApiAuthParams) @params);
		}

		/// <inheritdoc />
		public async Task AuthorizeAsync(IApiAuthParams @params, CancellationToken cancellationToken = default)
		{
			// если токен не задан - обычная авторизация
			if (@params.AccessToken == null)
			{
				await BaseAuthorizeAsync(@params, cancellationToken).ConfigureAwait(false);
			}

			// если токен задан - авторизация с помощью токена полученного извне
			else
			{
				TokenAuth(@params.AccessToken, @params.UserId, @params.TokenExpireTime);
			}

			_ap = @params;
			_logger?.LogDebug("Авторизация прошла успешно");
		}

		/// <inheritdoc />
		public void RefreshToken(Func<string> code = null)
		{
			RefreshTokenAsync(code, CancellationToken.None).GetAwaiter().GetResult();
		}

		/// <inheritdoc />
		public void LogOut()
		{
			LogOutAsync(CancellationToken.None).GetAwaiter().GetResult();
		}

		/// <inheritdoc />
		public async Task RefreshTokenAsync(Func<string> code = null, CancellationToken cancellationToken = default)
		{
			if (!string.IsNullOrWhiteSpace(_ap.Login) && !string.IsNullOrWhiteSpace(_ap.Password))
			{
				_ap.TwoFactorAuthorization = _ap.TwoFactorAuthorization ?? code;
				await BaseAuthorizeAsync(_ap, cancellationToken).ConfigureAwait(false);
			} else
			{
				const string message =
					"Невозможно обновить токен доступа т.к. последняя авторизация происходила не при помощи логина и пароля";

				_logger?.LogError(message);

				throw new AggregateException(message);
			}
		}

		/// <inheritdoc />
		public async Task LogOutAsync(CancellationToken cancellationToken = default)
		{
			AccessToken = string.Empty;
		}

		/// <inheritdoc />
		[MethodImpl(MethodImplOptions.NoInlining)]
		public VkResponse Call(string methodName, VkParameters parameters, bool skipAuthorization = false)
		{
			return CallAsync(methodName, parameters, skipAuthorization, CancellationToken.None).GetAwaiter().GetResult();
		}

		/// <inheritdoc />
		public async Task<VkResponse> CallAsync(string methodName, VkParameters parameters, bool skipAuthorization = false,
												CancellationToken cancellationToken = default)
		{
			var answer = await CallBaseAsync(methodName, parameters, skipAuthorization, cancellationToken).ConfigureAwait(false);

			var json = JObject.Parse(answer);

			var rawResponse = json["response"] ?? json;

			return new VkResponse(rawResponse)
			{
				RawJson = answer
			};
		}

		/// <inheritdoc />
		public async Task<T> CallAsync<T>(string methodName, VkParameters parameters, bool skipAuthorization = false,
										IEnumerable<JsonConverter> jsonConverters = default,
										CancellationToken cancellationToken = default)
		{
			var vkResponse = await CallAsync(methodName, parameters, skipAuthorization, cancellationToken).ConfigureAwait(false);

			return vkResponse.Token.ToObject<T>(_jsonSerializer);
		}

		/// <inheritdoc />
		[MethodImpl(MethodImplOptions.NoInlining)]
		public T Call<T>(string methodName, VkParameters parameters, bool skipAuthorization = false, params JsonConverter[] jsonConverters)
		{
			return CallAsync<T>(methodName, parameters, skipAuthorization, jsonConverters, CancellationToken.None).GetAwaiter().GetResult();
		}

		/// <inheritdoc />
		[CanBeNull]
		public string Invoke(string methodName, IDictionary<string, string> parameters, bool skipAuthorization = false)
		{
			return InvokeAsync(methodName, parameters, skipAuthorization, CancellationToken.None).GetAwaiter().GetResult();
		}

		/// <inheritdoc />
		[CanBeNull]
		public async Task<string> InvokeAsync(string methodName, IDictionary<string, string> parameters, bool skipAuthorization = false,
											CancellationToken cancellationToken = default)
		{
			if (!skipAuthorization && !IsAuthorized)
			{
				var message = $"Метод '{methodName}' нельзя вызывать без авторизации";
				_logger?.LogError(message);

				throw new AccessTokenInvalidException(message);
			}

			var url = $"https://api.vk.com/method/{methodName}";
			var answer = await InvokeBaseAsync(url, parameters, cancellationToken).ConfigureAwait(false);

			_logger?.LogTrace($"Uri = \"{url}\"");
			_logger?.LogTrace($"Json ={Environment.NewLine}{Utilities.PrettyPrintJson(answer)}");

			VkErrors.IfErrorThrowException(answer);

			return answer;
		}

		/// <inheritdoc />
		public VkResponse CallLongPoll(string server, VkParameters parameters)
		{
			return CallLongPollAsync(server, parameters, CancellationToken.None).GetAwaiter().GetResult();
		}

		/// <inheritdoc />
		public async Task<VkResponse> CallLongPollAsync(string server, VkParameters parameters,
														CancellationToken cancellationToken = default)
		{
			var answer = await InvokeLongPollAsync(server, parameters, cancellationToken).ConfigureAwait(false);

			var json = JObject.Parse(answer);

			var rawResponse = json.Root;

			return new VkResponse(rawResponse)
			{
				RawJson = answer
			};
		}

		/// <inheritdoc />
		public string InvokeLongPoll(string server, Dictionary<string, string> parameters)
		{
			return InvokeLongPollAsync(server, parameters, CancellationToken.None).GetAwaiter().GetResult();
		}

		/// <inheritdoc />
		public async Task<string> InvokeLongPollAsync(string server, Dictionary<string, string> parameters,
													CancellationToken cancellationToken = default)
		{
			if (string.IsNullOrEmpty(server))
			{
				const string message = "Server не должен быть пустым или null";
				_logger?.LogError(message);

				throw new ArgumentException(message);
			}

			_logger?.LogDebug(
				$"Вызов GetLongPollHistory с сервером {server}, с параметрами {string.Join(",", parameters.Select(x => $"{x.Key}={x.Value}"))}");

			var answer = await InvokeBaseAsync(server, parameters, cancellationToken).ConfigureAwait(false);

			_logger?.LogTrace($"Uri = '{server}'");
			_logger?.LogTrace($"Json ={Environment.NewLine}{Utilities.PrettyPrintJson(answer)}");

			VkErrors.IfErrorThrowException(answer);

			return answer;
		}

		/// <inheritdoc cref="IDisposable" />
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <inheritdoc />
		public void Validate(string validateUrl)
		{
			StopTimer();

			LastInvokeTime = DateTimeOffset.Now;
			var authorization = NeedValidationHandler.Validate(validateUrl);

			if (string.IsNullOrWhiteSpace(authorization.AccessToken))
			{
				const string message = "Не удалось автоматически пройти валидацию!";
				_logger?.LogError(message);

				throw new NeedValidationException(new VkError
				{
					ErrorMessage = message,
					RedirectUri = new Uri(validateUrl)
				});
			}

			AccessToken = authorization.AccessToken;
			UserId = authorization.UserId;
		}

		/// <inheritdoc cref="IVkApi.Validate" />
		[Obsolete(ObsoleteText.Validate)]
		public void Validate(string validateUrl, string phoneNumber)
		{
			_ap.Phone = phoneNumber;
			Validate(validateUrl);
		}

		/// <summary>
		/// Releases unmanaged and - optionally - managed resources.
		/// </summary>
		/// <param name="disposing">
		/// <c> true </c> to release both managed and unmanaged resources; <c> false </c>
		/// to release only unmanaged resources.
		/// </param>
		protected virtual void Dispose(bool disposing)
		{
			_expireTimer?.Dispose();
			RestClient?.Dispose();
		}

	#region Requests limit stuff

		/// <summary>
		/// The <see cref="IRateLimiter" />.
		/// </summary>
		private IRateLimiter _rateLimiter;

		/// <summary>
		/// Запросов в секунду.
		/// </summary>
		private int _requestsPerSecond;

		/// <inheritdoc />
		public DateTimeOffset? LastInvokeTime { get; private set; }

		/// <inheritdoc />
		public TimeSpan? LastInvokeTimeSpan
		{
			get
			{
				if (LastInvokeTime.HasValue)
				{
					return DateTimeOffset.Now - LastInvokeTime.Value;
				}

				return null;
			}
		}

		/// <inheritdoc />
		public int RequestsPerSecond
		{
			get => _requestsPerSecond;
			set
			{
				if (value < 0)
				{
					throw new ArgumentException(@"Value must be positive", nameof(value));
				}

				_requestsPerSecond = value;

				if (_requestsPerSecond == 0)
				{
					return;
				}

				_rateLimiter.SetRate(_requestsPerSecond, TimeSpan.FromSeconds(1));
			}
		}

	#endregion

	#region Captcha handler stuff

		/// <summary>
		/// Обработчик ошибки капчи
		/// </summary>
		private ICaptchaHandler _captchaHandler;

		/// <inheritdoc />
		public int MaxCaptchaRecognitionCount
		{
			get => _captchaHandler.MaxCaptchaRecognitionCount;
			set
			{
				if (value < 0)
				{
					throw new ArgumentException(@"Value must be positive", nameof(value));
				}

				if (value == 0)
				{
					return;
				}

				_captchaHandler.MaxCaptchaRecognitionCount = value;
			}
		}

	#endregion

	#region Categories Definition

		/// <inheritdoc />
		public IUsersCategory Users { get; private set; }

		/// <inheritdoc />
		public IFriendsCategory Friends { get; private set; }

		/// <inheritdoc />
		public IStatusCategory Status { get; private set; }

		/// <inheritdoc />
		public IMessagesCategory Messages { get; private set; }

		/// <inheritdoc />
		public IGroupsCategory Groups { get; private set; }

		/// <inheritdoc />
		public IAudioCategory Audio { get; private set; }

		/// <inheritdoc />
		public IDatabaseCategory Database { get; private set; }

		/// <inheritdoc />
		public IUtilsCategory Utils { get; private set; }

		/// <inheritdoc />
		public IWallCategory Wall { get; private set; }

		/// <inheritdoc />
		public IBoardCategory Board { get; private set; }

		/// <inheritdoc />
		public IFaveCategory Fave { get; private set; }

		/// <inheritdoc />
		public IVideoCategory Video { get; private set; }

		/// <inheritdoc />
		public IAccountCategory Account { get; private set; }

		/// <inheritdoc />
		public IPhotoCategory Photo { get; private set; }

		/// <inheritdoc />
		public IDocsCategory Docs { get; private set; }

		/// <inheritdoc />
		public ILikesCategory Likes { get; private set; }

		/// <inheritdoc />
		public IPagesCategory Pages { get; private set; }

		/// <inheritdoc />
		public IAppsCategory Apps { get; private set; }

		/// <inheritdoc />
		public INewsFeedCategory NewsFeed { get; private set; }

		/// <inheritdoc />
		public IStatsCategory Stats { get; private set; }

		/// <inheritdoc />
		public IGiftsCategory Gifts { get; private set; }

		/// <inheritdoc />
		public IMarketsCategory Markets { get; private set; }

		/// <inheritdoc />
		public IAuthCategory Auth { get; private set; }

		/// <inheritdoc />
		public IExecuteCategory Execute { get; private set; }

		/// <inheritdoc />
		public IPollsCategory PollsCategory { get; private set; }

		/// <inheritdoc />
		public ISearchCategory Search { get; private set; }

		/// <inheritdoc />
		public IStorageCategory Storage { get; set; }

		/// <inheritdoc />
		public IAdsCategory Ads { get; private set; }

		/// <inheritdoc />
		public INotificationsCategory Notifications { get; set; }

		/// <inheritdoc />
		public IWidgetsCategory Widgets { get; set; }

		/// <inheritdoc />
		public ILeadsCategory Leads { get; set; }

		/// <inheritdoc />
		public IStreamingCategory Streaming { get; set; }

		/// <inheritdoc />
		public IPlacesCategory Places { get; set; }

		///<inheritdoc />
		public INotesCategory Notes { get; set; }

		/// <inheritdoc />
		public IAppWidgetsCategory AppWidgets { get; set; }

		/// <inheritdoc />
		public IOrdersCategory Orders { get; set; }

		/// <inheritdoc />
		public ISecureCategory Secure { get; set; }

		/// <inheritdoc />
		public IStoriesCategory Stories { get; set; }

		/// <inheritdoc />
		public ILeadFormsCategory LeadForms { get; set; }

	#endregion

	#region private

		/// <summary>
		/// Базовое обращение к vk.com
		/// </summary>
		/// <param name="methodName"> Наименование метода </param>
		/// <param name="parameters"> Параметры запроса </param>
		/// <param name="skipAuthorization"> Пропустить авторизацию </param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <returns> Ответ от vk.com в формате json </returns>
		/// <exception cref="CaptchaNeededException"> Требуется ввести капчу </exception>
		private async Task<string> CallBaseAsync(string methodName, VkParameters parameters, bool skipAuthorization,
												CancellationToken cancellationToken = default)
		{
			if (!parameters.ContainsKey("v"))
			{
				parameters.Add("v", VkApiVersion.Version);
			}

			if (!parameters.ContainsKey(Constants.AccessToken))
			{
				parameters.Add(Constants.AccessToken, AccessToken);
			}

			if (!parameters.ContainsKey("lang") && _language.GetLanguage().HasValue)
			{
				parameters.Add("lang", _language.GetLanguage());
			}

			_logger?.LogDebug(
				$"Вызов метода {methodName}, с параметрами {string.Join(",", parameters.Where(x => x.Key != Constants.AccessToken).Select(x => $"{x.Key}={x.Value}"))}");

			return CaptchaSolver == null
				? await InvokeAsync(methodName, parameters, skipAuthorization, cancellationToken).ConfigureAwait(false)
				: await _captchaHandler.PerformAsync(async (sid, key) =>
						{
							parameters.Add("captcha_sid", sid);
							parameters.Add("captcha_key", key);

							return await InvokeAsync(methodName, parameters, skipAuthorization, cancellationToken).ConfigureAwait(false);
						},
						cancellationToken)
					.ConfigureAwait(false);
		}

		private Task<string> InvokeBaseAsync(string url, IDictionary<string, string> @params, CancellationToken cancellationToken = default)
		{
			if (_expireTimer == null)
			{
				SetTimer(0);
			}

			return _rateLimiter.Perform(async () =>
				{
					LastInvokeTime = DateTimeOffset.Now;

					var response = await RestClient.PostAsync(new Uri(url), @params, cancellationToken)
						.ConfigureAwait(false);

					return response.Value ?? response.Message;
				},
				cancellationToken);
		}

		/// <summary>
		/// Авторизация через установку токена
		/// </summary>
		/// <param name="accessToken"> Токен </param>
		/// <param name="userId"> Идентификатор пользователя </param>
		/// <param name="expireTime"> Время истечения токена </param>
		/// <exception cref="ArgumentNullException"> </exception>
		private void TokenAuth(string accessToken, long? userId, int expireTime)
		{
			if (string.IsNullOrWhiteSpace(accessToken))
			{
				_logger?.LogError("Авторизация через токен. Токен не задан.");

				throw new ArgumentNullException(accessToken);
			}

			_logger?.LogDebug("Авторизация через токен");
			StopTimer();

			LastInvokeTime = DateTimeOffset.Now;
			SetApiPropertiesAfterAuth(expireTime, accessToken, userId);
			_ap = new ApiAuthParams();
		}

		/// <summary>
		/// Sets the token properties.
		/// </summary>
		/// <param name="authorization"> The authorization. </param>
		private void SetTokenProperties(AuthorizationResult authorization)
		{
			_logger?.LogDebug("Установка свойств токена");
			var expireTime = (Convert.ToInt32(authorization.ExpiresIn) - 10) * 1000;
			SetApiPropertiesAfterAuth(expireTime, authorization.AccessToken, authorization.UserId);
		}

		/// <summary>
		/// Установить свойства api после авторизации
		/// </summary>
		/// <param name="expireTime"> </param>
		/// <param name="accessToken"> </param>
		/// <param name="userId"> </param>
		private void SetApiPropertiesAfterAuth(int expireTime, string accessToken, long? userId)
		{
			SetTimer(expireTime);
			AccessToken = accessToken;
			UserId = userId;
		}

		/// <summary>
		/// Установить значение таймера
		/// </summary>
		/// <param name="expireTime"> Значение таймера </param>
		private void SetTimer(int expireTime)
		{
			_expireTimer = new Timer(AlertExpires,
				null,
				expireTime > 0 ? expireTime : Timeout.Infinite,
				Timeout.Infinite);
		}

		/// <summary>
		/// Прекращает работу таймера оповещения
		/// </summary>
		private void StopTimer()
		{
			_expireTimer?.Dispose();
		}

		/// <summary>
		/// Создает событие оповещения об окончании времени токена
		/// </summary>
		/// <param name="state"> </param>
		private void AlertExpires(object state)
		{
			OnTokenExpires?.Invoke(this);
		}

		/// <summary>
		/// Авторизация и получение токена
		/// </summary>
		/// <param name="authParams"> Параметры авторизации </param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <exception cref="VkApiAuthorizationException"> </exception>
		private async Task BaseAuthorizeAsync(IApiAuthParams authParams, CancellationToken cancellationToken = default)
		{
			_logger?.LogDebug("Старт авторизации");

			StopTimer();

			LastInvokeTime = DateTimeOffset.Now;

			AuthorizationFlow.SetAuthorizationParams(authParams);
			var authorization = await AuthorizationFlow.AuthorizeAsync(cancellationToken).ConfigureAwait(false);

			if (string.IsNullOrWhiteSpace(authorization.AccessToken))
			{
				var message = $"Invalid authorization with {authParams.Login} - {authParams.Password}";
				_logger?.LogError(message);

				throw new VkApiAuthorizationException(message, authParams.Login, authParams.Password);
			}

			SetTokenProperties(authorization);
		}

		private void Initialization(IServiceProvider serviceProvider)
		{
			_logger = serviceProvider.GetService<ILogger<VkApi>>();
			_captchaHandler = serviceProvider.GetRequiredService<ICaptchaHandler>();
			_language = serviceProvider.GetRequiredService<ILanguageService>();
			_rateLimiter = serviceProvider.GetRequiredService<IRateLimiter>();

			_jsonSerializer = new JsonSerializer
			{
				Converters =
				{
					new VkCollectionJsonConverter(),
					new WallGetObjectJsonConverter(),
					new UnixDateTimeConverter(),
					new AttachmentJsonConverter(),
					new StringEnumConverter()
				},
				ContractResolver = new DefaultContractResolver
				{
					NamingStrategy = new SnakeCaseNamingStrategy()
				},
				NullValueHandling = NullValueHandling.Ignore,
				DefaultValueHandling = DefaultValueHandling.Ignore
			};

			NeedValidationHandler = serviceProvider.GetRequiredService<INeedValidationHandler>();
			AuthorizationFlow = serviceProvider.GetRequiredService<IAuthorizationFlow>();
			CaptchaSolver = serviceProvider.GetService<ICaptchaSolver>();
			RestClient = serviceProvider.GetRequiredService<IRestClient>();
			VkApiVersion = serviceProvider.GetRequiredService<IVkApiVersionManager>();

			Users = new UsersCategory(this);
			Friends = new FriendsCategory(this);
			Status = new StatusCategory(this);
			Messages = new MessagesCategory(this);
			Groups = new GroupsCategory(this);
			Audio = new AudioCategory(this);
			Wall = new WallCategory(this);
			Board = new BoardCategory(this);
			Database = new DatabaseCategory(this);
			Utils = new UtilsCategory(this);
			Fave = new FaveCategory(this);
			Video = new VideoCategory(this);
			Account = new AccountCategory(this);
			Photo = new PhotoCategory(this);
			Docs = new DocsCategory(this);
			Likes = new LikesCategory(this);
			Pages = new PagesCategory(this);
			Gifts = new GiftsCategory(this);
			Apps = new AppsCategory(this);
			NewsFeed = new NewsFeedCategory(this);
			Stats = new StatsCategory(this);
			Auth = new AuthCategory(this);
			Markets = new MarketsCategory(this);
			Execute = new ExecuteCategory(this);
			PollsCategory = new PollsCategory(this);
			Search = new SearchCategory(this);
			Ads = new AdsCategory(this);
			Storage = new StorageCategory(this);
			Notifications = new NotificationsCategory(this);
			Widgets = new WidgetsCategory(this);
			Leads = new LeadsCategory(this);
			Streaming = new StreamingCategory(this);
			Places = new PlacesCategory(this);
			Notes = new NotesCategory(this);
			AppWidgets = new AppWidgetsCategory(this);
			Orders = new OrdersCategory(this);
			Secure = new SecureCategory(this);
			Stories = new StoriesCategory(this);
			LeadForms = new LeadFormsCategory(this);

			RequestsPerSecond = 3;

			MaxCaptchaRecognitionCount = 5;
			_logger?.LogDebug("VkApi Initialization successfully");
		}

	#endregion
	}
}