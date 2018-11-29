// ReSharper disable once RedundantUsingDirective
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using VkNet.Abstractions;
using VkNet.Abstractions.Authorization;
using VkNet.Abstractions.Category;
using VkNet.Abstractions.Core;
using VkNet.Abstractions.Utils;
using VkNet.Categories;
using VkNet.Enums;
using VkNet.Enums.Filters;
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
	/// <inheritdoc />
	/// <summary>
	/// API для работы с ВКонтакте.
	/// Выступает в качестве фабрики для различных категорий API (например, для работы
	/// с пользователями, группами и т.п.)
	/// </summary>
	public class VkApi : IVkApi
	{
		/// <summary>
		/// Обработчик ошибки капчи
		/// </summary>
		private ICaptchaHandler _captchaHandler;

		/// <summary>
		/// Сервис управления языком
		/// </summary>
		private ILanguageService _language;

		/// <summary>
		/// Логгер
		/// </summary>
		private ILogger<VkApi> _logger;

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
		/// Версия API vk.com.
		/// </summary>
		public IVkApiVersionManager VkApiVersion { get; private set; }

		/// <inheritdoc />
		public IAuthorizationFlow AuthorizationFlow { get; set; }

		/// <inheritdoc />
		public ITokenManager AccessToken { get; set; }

		/// <inheritdoc />
		public int MaxCaptchaRecognitionCount { get; set; }

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
		public void Authorize([NotNull] IAuthorizationFlow authorizationFlow)
		{
			if (authorizationFlow == null)
			{
				throw new ArgumentNullException(nameof(authorizationFlow));
			}

			AuthorizationResult authorizationResult;

			if (CaptchaSolver != null)
			{
				authorizationResult = _captchaHandler.Perform((sid, key) =>
				{
					var authParams = AuthorizationFlow.GetAuthParams();
					authParams.CaptchaSid = sid;
					authParams.CaptchaKey = key;
					AuthorizationFlow.SetAuthParams(authParams);

					return authorizationFlow.Authorize();
				});
			} else
			{
				authorizationResult = authorizationFlow.Authorize();
			}

			AccessToken = new TokenManager(this, _logger)
			{
				Token = authorizationResult.AccessToken,
				UserId = authorizationResult.UserId,
				ExpireTime = authorizationResult.ExpiresIn
			};

			_logger?.LogDebug("Авторизация прошла успешно");
		}
		/// <inheritdoc />
		public void Authorize(ApiAuthParams @params) => Authorize((IApiAuthParams)@params);

		/// <inheritdoc cref="IVkApiAuth.Authorize"/>
		public void Authorize()
		{
			Authorize(AuthorizationFlow);
		}

		/// <inheritdoc />
		public Task AuthorizeAsync(IAuthorizationFlow authorizationFlow)
		{
			return TypeHelper.TryInvokeMethodAsync(() => Authorize(authorizationFlow));
		}

		/// <inheritdoc cref="IVkApiAuth.Authorize"/>
		public Task AuthorizeAsync()
		{
			return TypeHelper.TryInvokeMethodAsync(() => Authorize());
		}

		/// <inheritdoc />
		public void LogOut()
		{
			AccessToken = new TokenManager();
		}

		/// <inheritdoc />
		public Task LogOutAsync()
		{
			return TypeHelper.TryInvokeMethodAsync(LogOut);
		}

		/// <inheritdoc />
		[MethodImpl(MethodImplOptions.NoInlining)]
		public VkResponse Call(string methodName, VkParameters parameters, bool skipAuthorization = false)
		{
			var answer = CallBase(methodName, parameters, skipAuthorization);

			var json = JObject.Parse(answer);

			var rawResponse = json["response"];

			return new VkResponse(rawResponse) { RawJson = answer };
		}

		/// <inheritdoc />
		public Task<VkResponse> CallAsync(string methodName, VkParameters parameters, bool skipAuthorization = false)
		{
			var task = TypeHelper.TryInvokeMethodAsync(() =>
				Call(methodName, parameters, skipAuthorization));

			task.ConfigureAwait(false);

			return task;
		}

		/// <inheritdoc />
		public Task<T> CallAsync<T>(string methodName, VkParameters parameters, bool skipAuthorization = false)
		{
			var task = TypeHelper.TryInvokeMethodAsync(() =>
				Call<T>(methodName, parameters, skipAuthorization));

			task.ConfigureAwait(false);

			return task;
		}

		/// <inheritdoc />
		[MethodImpl(MethodImplOptions.NoInlining)]
		public T Call<T>(string methodName, VkParameters parameters, bool skipAuthorization = false, params JsonConverter[] jsonConverters)
		{
			var answer = CallBase(methodName, parameters, skipAuthorization);

			if (!jsonConverters.Any())
			{
				return JsonConvert.DeserializeObject<T>(answer,
					new VkCollectionJsonConverter(),
					new VkDefaultJsonConverter(),
					new UnixDateTimeConverter(),
					new AttachmentJsonConverter(),
					new StringEnumConverter());
			}

			return JsonConvert.DeserializeObject<T>(answer, jsonConverters);
		}

		/// <inheritdoc />
		[CanBeNull]
		public string Invoke(string methodName, IDictionary<string, string> parameters, bool skipAuthorization = false)
		{
			if (!skipAuthorization && !AccessToken.IsAuthorized)
			{
				var message = $"Метод '{methodName}' нельзя вызывать без авторизации";
				_logger?.LogError(message);

				throw new AccessTokenInvalidException(message);
			}

			var url = $"https://api.vk.com/method/{methodName}";
			var answer = InvokeBase(url, parameters, skipAuthorization);

			_logger?.LogTrace($"Uri = \"{url}\"");
			_logger?.LogTrace($"Json ={Environment.NewLine}{Utilities.PreetyPrintJson(answer)}");

			VkErrors.IfErrorThrowException(answer);

			return answer;
		}

		/// <inheritdoc />
		[CanBeNull]
		public Task<string> InvokeAsync(string methodName, IDictionary<string, string> parameters, bool skipAuthorization = false)
		{
			return TypeHelper.TryInvokeMethodAsync(() =>
				Invoke(methodName, parameters, skipAuthorization));
		}

		/// <inheritdoc />
		public VkResponse CallLongPoll(string server, VkParameters parameters)
		{
			var answer = InvokeLongPoll(server, parameters);

			var json = JObject.Parse(answer);

			var rawResponse = json.Root;

			return new VkResponse(rawResponse) { RawJson = answer };
		}

		/// <inheritdoc />
		public Task<VkResponse> CallLongPollAsync(string server, VkParameters parameters)
		{
			return TypeHelper.TryInvokeMethodAsync(() => CallLongPoll(server, parameters));
		}

		/// <inheritdoc />
		public string InvokeLongPoll(string server, Dictionary<string, string> parameters)
		{
			if (string.IsNullOrEmpty(server))
			{
				var message = "Server не должен быть пустым или null";
				_logger?.LogError(message);

				throw new ArgumentException(message);
			}

			_logger?.LogDebug(
				$"Вызов GetLongPollHistory с сервером {server}, с параметрами {string.Join(",", parameters.Select(x => $"{x.Key}={x.Value}"))}");

			var answer = InvokeBase(server, parameters);

			_logger?.LogTrace($"Uri = \"{server}\"");
			_logger?.LogTrace($"Json ={Environment.NewLine}{Utilities.PreetyPrintJson(answer)}");

			VkErrors.IfErrorThrowException(answer);

			return answer;
		}

		/// <inheritdoc />
		public Task<string> InvokeLongPollAsync(string server, Dictionary<string, string> parameters)
		{
			return TypeHelper.TryInvokeMethodAsync(() =>
				InvokeLongPoll(server, parameters));
		}

		/// <inheritdoc cref="IDisposable" />
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Releases unmanaged and - optionally - managed resources.
		/// </summary>
		/// <param name="disposing">
		/// <c> true </c> to release both managed and unmanaged resources; <c> false </c>
		/// to release only
		/// unmanaged resources.
		/// </param>
		protected virtual void Dispose(bool disposing)
		{
			AccessToken?.Dispose();
		}

	#region Requests limit stuff

		/// <summary>
		/// The <see cref="IRateLimiter"/>.
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

				if (_requestsPerSecond <= 0)
				{
					return;
				}

				_rateLimiter.SetRate(_requestsPerSecond, TimeSpan.FromSeconds(1));
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
		/// <returns> Ответ от vk.com в формате json </returns>
		/// <exception cref="CaptchaNeededException"> Требуется ввести капчу </exception>
		private string CallBase(string methodName, VkParameters parameters, bool skipAuthorization)
		{
			if (!parameters.ContainsKey("v"))
			{
				parameters.Add("v", VkApiVersion.Version);
			}

			if (!parameters.ContainsKey(Constants.AccessToken))
			{
				parameters.Add(Constants.AccessToken, AccessToken.Token);
			}

			if (!parameters.ContainsKey("lang") && _language.GetLanguage().HasValue)
			{
				parameters.Add("lang", _language.GetLanguage());
			}

			var clientSecret = AuthorizationFlow?.GetAuthParams()?.ClientSecret;

			if (!string.IsNullOrWhiteSpace(clientSecret) && !parameters.ContainsKey("client_secret"))
			{
				parameters.Add("client_secret", clientSecret);
			}

			_logger?.LogDebug(
				$"Вызов метода {methodName}, с параметрами {string.Join(",", parameters.Where(x => x.Key != Constants.AccessToken).Select(x => $"{x.Key}={x.Value}"))}");

			string answer;

			if (CaptchaSolver == null)
			{
				answer = Invoke(methodName, parameters, skipAuthorization);
			} else
			{
				answer = _captchaHandler.Perform((sid, key) =>
				{
					parameters.Add("captcha_sid", sid);
					parameters.Add("captcha_key", key);

					return Invoke(methodName, parameters, skipAuthorization);
				});
			}

			return answer;
		}

		private string InvokeBase(string url, IDictionary<string, string> @params, bool skipAuthorization = false)
		{
			var answer = string.Empty;

			void SendRequest()
			{
				LastInvokeTime = DateTimeOffset.Now;

				var response = RestClient.PostAsync(new Uri(url), @params)
					.ConfigureAwait(false)
					.GetAwaiter()
					.GetResult();

				answer = response.Message ?? response.Value;
			}

			// Защита от превышения количества запросов в секунду
			_rateLimiter.Perform(() => SendRequest()).ConfigureAwait(false).GetAwaiter().GetResult();

			return answer;
		}

		private void Initialization(IServiceProvider serviceProvider)
		{
			AuthorizationFlow = serviceProvider.GetRequiredService<IAuthorizationFlow>();
			CaptchaSolver = serviceProvider.GetService<ICaptchaSolver>();
			_logger = serviceProvider.GetService<ILogger<VkApi>>();
			_captchaHandler = serviceProvider.GetRequiredService<ICaptchaHandler>();
			_language = serviceProvider.GetRequiredService<ILanguageService>();
			_rateLimiter = serviceProvider.GetRequiredService<IRateLimiter>();

			RestClient = serviceProvider.GetRequiredService<IRestClient>();
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

			VkApiVersion = serviceProvider.GetRequiredService<IVkApiVersionManager>();

			RequestsPerSecond = 3;

			MaxCaptchaRecognitionCount = 5;
			_logger?.LogDebug("VkApi Initialization successfully");
		}

	#endregion
	}
}