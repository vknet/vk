using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Flurl;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using VkNet.Abstractions.Core;
using VkNet.Enums;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Exception;
using VkNet.Infrastructure.Authorization.ImplicitFlow;
using VkNet.Model;
using VkNet.Utils.AntiCaptcha;

namespace VkNet.Utils
{
	/// <inheritdoc />
	public partial class Browser : IBrowser
	{
		/// <summary>
		/// Логгер
		/// </summary>
		[CanBeNull]
		private readonly ILogger<Browser> _logger;

		private IApiAuthParams _authParams;

		/// <summary>
		/// Менеджер версий VkApi
		/// </summary>
		private readonly IVkApiVersionManager _versionManager;

		private readonly IVkAuthorization<ImplicitFlowPageType> _vkAuthorization;

		private readonly ICaptchaSolver _captchaSolver;

		private ushort LoginPasswordError { get; set; }

		private const ushort MaxLoginPasswordError = 1;

		/// <inheritdoc />
		public Browser([CanBeNull] ILogger<Browser> logger,
						IVkApiVersionManager versionManager,
						IWebProxy proxy,
						IVkAuthorization<ImplicitFlowPageType> vkAuthorization,
						ICaptchaSolver captchaSolver)
		{
			_logger = logger;
			_versionManager = versionManager;
			Proxy = proxy;
			_vkAuthorization = vkAuthorization;
			_captchaSolver = captchaSolver;
		}

		/// <inheritdoc />
		public IWebProxy Proxy { get; set; }

		/// <inheritdoc />
		public string GetJson(string url, IEnumerable<KeyValuePair<string, string>> parameters)
		{
			return WebCall.PostCall(url, parameters, Proxy).Response;
		}

		/// <inheritdoc />
		public void SetAuthorizationParams(IApiAuthParams authorizationParams)
		{
			_authParams = authorizationParams;
		}

		/// <inheritdoc />
		public async Task<AuthorizationResult> AuthorizeAsync()
		{
			var result = await AuthorizeAsync(_authParams).ConfigureAwait(false);

			return result;
		}

		/// <inheritdoc />
		public Url CreateAuthorizeUrl(ulong clientId, ulong scope, Display display, string state)
		{
			var builder = new StringBuilder("https://oauth.vk.com/authorize?");

			builder.Append($"client_id={clientId}&");
			builder.Append("redirect_uri=https://oauth.vk.com/blank.html&");
			builder.Append($"display={display}&");
			builder.Append($"scope={scope}&");
			builder.Append("response_type=token&");
			builder.Append($"v={_versionManager.Version}&");
			builder.Append($"state={state}&");
			builder.Append("revoke=1");

			return new Uri(builder.ToString());
		}

		/// <inheritdoc />
		public AuthorizationResult Validate(string validateUrl, string phoneNumber)
		{
			var result = OldValidate(validateUrl, phoneNumber);

			return new AuthorizationResult
			{
				AccessToken = result.AccessToken,
				ExpiresIn = result.ExpiresIn,
				UserId = result.ExpiresIn,
				State = result.State
			};
		}

		/// <inheritdoc />
		public AuthorizationResult Validate(string validateUrl)
		{
			var result = OldValidate(validateUrl, _authParams.Phone);

			return new AuthorizationResult
			{
				AccessToken = result.AccessToken,
				ExpiresIn = result.ExpiresIn,
				UserId = result.ExpiresIn,
				State = result.State
			};
		}

		/// <inheritdoc />
		public async Task<AuthorizationResult> ValidateAsync(string validateUrl)
		{
			var result = await OldValidateAsync(validateUrl, _authParams.Phone).ConfigureAwait(false);

			return new AuthorizationResult
			{
				AccessToken = result.AccessToken,
				ExpiresIn = result.ExpiresIn,
				UserId = result.ExpiresIn,
				State = result.State
			};
		}

		/// <summary>
		/// Заполнить форму двухфакторной авторизации
		/// </summary>
		/// <param name="code"> Функция возвращающая код двухфакторной авторизации </param>
		/// <param name="loginFormPostResult"> Ответ сервера vk </param>
		/// <returns> Ответ сервера vk </returns>
		private WebCallResult FilledTwoFactorForm(Func<string> code, WebCallResult loginFormPostResult)
		{
			var codeForm = WebForm.From(loginFormPostResult)
				.WithField("code")
				.FilledWith(code.Invoke());

			return WebCall.Post(codeForm, Proxy);
		}

		/// <summary>
		/// Проверка наличия двухфакторной авторизации
		/// </summary>
		/// <param name="code"> Функция возвращающая код двухфакторной авторизации </param>
		/// <param name="loginFormPostResult"> Ответ сервера vk </param>
		/// <returns> </returns>
		private bool HasNotTwoFactor(Func<string> code, WebCallResult loginFormPostResult)
		{
			_logger?.LogDebug("Проверка наличия двухфакторной авторизации");

			return code == null || WebForm.IsOAuthBlank(loginFormPostResult);
		}

		/// <summary>
		/// Заполнить форму логин и пароль
		/// </summary>
		/// <param name="email"> Логин </param>
		/// <param name="password"> Пароль </param>
		/// <param name="authorizeUrlResult"> </param>
		/// <returns> </returns>
		private WebCallResult FilledLoginForm(string email, string password, WebCallResult authorizeUrlResult)
		{
			var loginForm = WebForm.From(authorizeUrlResult)
				.WithField("email")
				.FilledWith(email)
				.And()
				.WithField("pass")
				.FilledWith(password);

			return WebCall.Post(loginForm, Proxy);
		}

		/// <summary>
		/// Заполнить форму логин и пароль
		/// </summary>
		/// <param name="email"> Логин </param>
		/// <param name="password"> Пароль </param>
		/// <param name="authorizeUrlResult"> </param>
		/// <returns> </returns>
		private WebCallResult FilledCaptchaLoginForm(string email, string password, WebCallResult authorizeUrlResult)
		{
			var loginForm = WebForm.From(authorizeUrlResult)
				.WithField("email")
				.FilledWith(email)
				.And()
				.WithField("pass")
				.FilledWith(password);

			_logger?.LogDebug("Шаг 2. Заполнение формы логина. Капча");

			var captchaKey =
				_captchaSolver.Solve(
					$"https://api.vk.com//captcha.php?sid={loginForm.GetFieldValue(AuthorizationFormFields.CaptchaSid)}&s=1");

			loginForm.WithField("captcha_key")
				.FilledWith(captchaKey);

			return WebCall.Post(loginForm, Proxy);
		}

		/// <summary>
		/// Закончить авторизацию
		/// </summary>
		/// <param name="result"> Результат </param>
		/// <param name="webProxy"> Настройки прокси </param>
		/// <returns> </returns>
		/// <exception cref="CaptchaNeededException"> </exception>
		private VkAuthorization2 EndAuthorize(WebCallResult result, IWebProxy webProxy = null)
		{
			if (IsAuthSuccessfull(result))
			{
				var auth = GetTokenUri(result);

				return VkAuthorization2.From(auth.ToString());
			}

			if (HasСonfirmationRights(result))
			{
				_logger?.LogDebug("Требуется подтверждение прав");
				var authorizationForm = WebForm.From(result);
				var authorizationFormPostResult = WebCall.Post(authorizationForm, webProxy);

				if (!IsAuthSuccessfull(authorizationFormPostResult))
				{
					throw new VkApiException("URI должен содержать токен!");
				}

				var tokenUri = GetTokenUri(authorizationFormPostResult);

				return VkAuthorization2.From(tokenUri.ToString());
			}

			var captchaSid = HasCaptchaInput(result);

			if (!captchaSid.HasValue)
			{
				throw new VkApiException("Непредвиденная ошибка авторизации. Обратитесь к разработчику.");
			}

			_logger?.LogDebug("Требуется ввод капчи");

			throw new CaptchaNeededException(captchaSid.Value, "https://m.vk.com/captcha.php?sid=" + captchaSid.Value);
		}

		private bool HasСonfirmationRights(WebCallResult result)
		{
			var request = VkAuthorization2.From(result.RequestUrl.ToString());
			var response = VkAuthorization2.From(result.ResponseUrl.ToString());

			return request.IsAuthorizationRequired || response.IsAuthorizationRequired;
		}

		private long? HasCaptchaInput(WebCallResult result)
		{
			var request = VkAuthorization2.From(result.RequestUrl.ToString());
			var response = VkAuthorization2.From(result.ResponseUrl.ToString());

			if (request.IsCaptchaNeeded)
			{
				return request.CaptchaSid;
			}

			if (response.IsCaptchaNeeded)
			{
				return response.CaptchaSid;
			}

			return null;
		}

		/// <summary>
		/// Открытие окна авторизации
		/// </summary>
		/// <param name="appId"> id приложения </param>
		/// <param name="settings"> Настройки приложения </param>
		/// <returns> </returns>
		private WebCallResult OpenAuthDialog(ulong appId, [NotNull] Settings settings)
		{
			var url = CreateAuthorizeUrl(appId, settings.ToUInt64(), Display.Page, "123456");

			return WebCall.MakeCall(url.ToString(), Proxy);
		}

		/// <summary>
		/// Авторизация прошла успешно
		/// </summary>
		/// <param name="webCallResult"> </param>
		/// <returns> true, если авторизация прошла успешно </returns>
		private static bool IsAuthSuccessfull(WebCallResult webCallResult)
		{
			return UriHasAccessToken(webCallResult.RequestUrl) || UriHasAccessToken(webCallResult.ResponseUrl);
		}

		/// <summary>
		/// Проверка наличия токена в url
		/// </summary>
		/// <param name="uri"> </param>
		/// <returns> </returns>
		private static bool UriHasAccessToken(Uri uri)
		{
			return uri.Fragment
				.StartsWith("#access_token=", StringComparison.Ordinal);
		}

		/// <summary>
		/// Получить токен из uri
		/// </summary>
		/// <param name="webCallResult"> Результат запроса </param>
		/// <returns> Возвращает uri содержащий токен </returns>
		/// <exception cref="VkApiException"> URI должен содержать токен! </exception>
		private Uri GetTokenUri(WebCallResult webCallResult)
		{
			if (UriHasAccessToken(webCallResult.RequestUrl))
			{
				_logger?.LogDebug("Запрос: " + webCallResult.RequestUrl);

				return webCallResult.RequestUrl;
			}

			if (UriHasAccessToken(webCallResult.ResponseUrl))
			{
				_logger?.LogDebug("Ответ: " + webCallResult.ResponseUrl);

				return webCallResult.ResponseUrl;
			}

			return null;
		}

		private AuthorizationResult Authorize(IApiAuthParams authParams)
		{
			var authorizeUrlResult = OpenAuthDialog(authParams.ApplicationId, authParams.Settings);

			return NextStep(authorizeUrlResult);
		}

		private VkAuthorization2 OldValidate(string validateUrl, string phoneNumber)
		{
			if (string.IsNullOrWhiteSpace(validateUrl))
			{
				throw new ArgumentException("Не задан адрес валидации!");
			}

			if (string.IsNullOrWhiteSpace(phoneNumber))
			{
				throw new ArgumentException("Не задан номер телефона!");
			}

			var validateUrlResult = WebCall.MakeCall(validateUrl, Proxy);

			var codeForm = WebForm.From(validateUrlResult)
				.WithField("code")
				.FilledWith(phoneNumber.Substring(1, 8));

			var codeFormPostResult = WebCall.Post(codeForm, Proxy);

			return EndAuthorize(codeFormPostResult, Proxy);
		}

		private async Task<VkAuthorization2> OldValidateAsync(string validateUrl, string phoneNumber)
		{
			if (string.IsNullOrWhiteSpace(validateUrl))
			{
				throw new ArgumentException("Не задан адрес валидации!");
			}

			if (string.IsNullOrWhiteSpace(phoneNumber))
			{
				throw new ArgumentException("Не задан номер телефона!");
			}

			var validateUrlResult = await WebCall.MakeCallAsync(validateUrl, Proxy).ConfigureAwait(false);

			var codeForm = WebForm.From(validateUrlResult)
				.WithField("code")
				.FilledWith(phoneNumber.Substring(1, 8));

			var codeFormPostResult = await WebCall.PostAsync(codeForm, Proxy).ConfigureAwait(false);

			return await EndAuthorizeAsync(codeFormPostResult, Proxy).ConfigureAwait(false);
		}

		private async Task<AuthorizationResult> NextStepAsync(WebCallResult formResult)
		{
			var pageType = _vkAuthorization.GetPageType(formResult.ResponseUrl);
			WebCallResult resultForm = null;

			switch (pageType)
			{
				case ImplicitFlowPageType.Error:

				{
					_logger?.LogError("При авторизации произошла ошибка.");

					throw new VkAuthorizationException("При авторизации произошла ошибка.");
				}

				case ImplicitFlowPageType.LoginPassword:

				{
					LoginPasswordError++;

					if (LoginPasswordError >= MaxLoginPasswordError)
					{
						throw new VkAuthorizationException("Неверный логин или пароль.");
					}

					_logger?.LogDebug("Ввод логина и пароля.");

					resultForm = await FilledLoginFormAsync(_authParams.Login,
							_authParams.Password,
							_authParams.CaptchaSid,
							_authParams.CaptchaKey,
							formResult)
						.ConfigureAwait(false);

					break;
				}

				case ImplicitFlowPageType.Captcha:

				{
					_logger?.LogDebug("Капча.");

					resultForm = await FilledLoginFormAsync(_authParams.Login,
							_authParams.Password,
							_authParams.CaptchaSid,
							_authParams.CaptchaKey,
							formResult)
						.ConfigureAwait(false);

					break;
				}

				case ImplicitFlowPageType.TwoFactor:

				{
					_logger?.LogDebug("Двухфакторная авторизация.");
					resultForm = await FilledTwoFactorFormAsync(_authParams.TwoFactorAuthorization, formResult).ConfigureAwait(false);

					break;
				}

				case ImplicitFlowPageType.Consent:

				{
					_logger?.LogDebug("Страница подтверждения доступа к скоупам.");
					resultForm = await FilledConsentAsync(formResult).ConfigureAwait(false);

					break;
				}

				case ImplicitFlowPageType.Result:

				{
					return _vkAuthorization.GetAuthorizationResult(formResult.ResponseUrl);
				}
			}

			return await NextStepAsync(resultForm).ConfigureAwait(false);
		}

		private AuthorizationResult NextStep(WebCallResult formResult)
		{
			var pageType = _vkAuthorization.GetPageType(formResult.ResponseUrl);
			WebCallResult resultForm = null;

			switch (pageType)
			{
				case ImplicitFlowPageType.Error:

				{
					_logger?.LogError("При авторизации произошла ошибка.");

					throw new VkAuthorizationException("При авторизации произошла ошибка.");
				}

				case ImplicitFlowPageType.LoginPassword:

				{
					LoginPasswordError++;

					if (LoginPasswordError >= MaxLoginPasswordError)
					{
						throw new VkAuthorizationException("Неверный логин или пароль.");
					}

					_logger?.LogDebug("Ввод логина и пароля.");

					resultForm = FilledLoginForm(_authParams.Login,
						_authParams.Password,
						formResult);

					break;
				}

				case ImplicitFlowPageType.Captcha:

				{
					_logger?.LogDebug("Капча.");

					resultForm = FilledLoginForm(_authParams.Login,
						_authParams.Password,
						formResult);

					break;
				}

				case ImplicitFlowPageType.TwoFactor:

				{
					_logger?.LogDebug("Двухфакторная авторизация.");
					resultForm = FilledTwoFactorForm(_authParams.TwoFactorAuthorization, formResult);

					break;
				}

				case ImplicitFlowPageType.Consent:

				{
					_logger?.LogDebug("Страница подтверждения доступа к скоупам.");
					resultForm = FilledConsent(formResult);

					break;
				}

				case ImplicitFlowPageType.Result:

				{
					return _vkAuthorization.GetAuthorizationResult(formResult.ResponseUrl);
				}
				default:

					throw new VkApiException("Не найден ни один тип для параметра " + nameof(pageType));
			}

			return NextStep(resultForm);
		}
	}
}