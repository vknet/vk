using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Flurl;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using VkNet.Abstractions.Core;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Exception;
using VkNet.Model;

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

		private readonly ApiAuthParams _authParams;

		/// <summary>
		/// Менеджер версий VkApi
		/// </summary>
		private readonly IVkApiVersionManager _versionManager;

		/// <inheritdoc />
		public Browser([CanBeNull] ILogger<Browser> logger, IVkApiVersionManager versionManager, ApiAuthParams authParams, IWebProxy proxy)
		{
			_logger = logger;
			_versionManager = versionManager;
			_authParams = authParams;
			Proxy = proxy;
		}

		/// <inheritdoc />
		public IWebProxy Proxy { get; set; }

		/// <inheritdoc />
		public string GetJson(string url, IEnumerable<KeyValuePair<string, string>> parameters)
		{
			return WebCall.PostCall(url, parameters, Proxy).Response;
		}

		public void SetAuthParams(IApiAuthParams authParams)
		{
			throw new NotImplementedException();
		}

		/// <inheritdoc />
		public async Task<AuthorizationResult> AuthorizeAsync()
		{
			var result = await AuthorizeAsync(_authParams).ConfigureAwait(false);

			return new AuthorizationResult
			{
				AccessToken = result.AccessToken,
				ExpiresIn = result.ExpiresIn,
				UserId = result.UserId,
				State = result.State
			};
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
		/// <param name="captchaSid"> ИД капчи </param>
		/// <param name="captchaKey"> Значение капчи </param>
		/// <param name="authorizeUrlResult"> </param>
		/// <returns> </returns>
		private WebCallResult FilledLoginForm(string email
											, string password
											, long? captchaSid
											, string captchaKey
											, WebCallResult authorizeUrlResult)
		{
			var loginForm = WebForm.From(authorizeUrlResult)
				.WithField("email")
				.FilledWith(email)
				.And()
				.WithField("pass")
				.FilledWith(password);

			if (!captchaSid.HasValue)
			{
				return WebCall.Post(loginForm, Proxy);
			}

			_logger?.LogDebug("Шаг 2. Заполнение формы логина. Капча");

			loginForm.WithField("captcha_sid")
				.FilledWith(captchaSid.Value.ToString())
				.WithField("captcha_key")
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

		private VkAuthorization2 Authorize(IApiAuthParams authParams)
		{
			_logger?.LogDebug("Шаг 1. Открытие диалога авторизации");
			var authorizeUrlResult = OpenAuthDialog(authParams.ApplicationId, authParams.Settings);

			if (IsAuthSuccessfull(authorizeUrlResult))
			{
				return EndAuthorize(authorizeUrlResult, Proxy);
			}

			_logger?.LogDebug("Шаг 2. Заполнение формы логина");

			var loginFormPostResult = FilledLoginForm(authParams.Login,
				authParams.Password,
				authParams.CaptchaSid,
				authParams.CaptchaKey,
				authorizeUrlResult);

			if (IsAuthSuccessfull(loginFormPostResult))
			{
				return EndAuthorize(loginFormPostResult, Proxy);
			}

			if (HasNotTwoFactor(authParams.TwoFactorAuthorization, loginFormPostResult))
			{
				return EndAuthorize(loginFormPostResult, Proxy);
			}

			_logger?.LogDebug("Шаг 2.5.1. Заполнить код двухфакторной авторизации");

			var twoFactorFormResult =
				FilledTwoFactorForm(authParams.TwoFactorAuthorization, loginFormPostResult);

			if (IsAuthSuccessfull(twoFactorFormResult))
			{
				return EndAuthorize(twoFactorFormResult, Proxy);
			}

			_logger?.LogDebug("Шаг 2.5.2 Капча");
			var captchaForm = WebForm.From(twoFactorFormResult);

			var captcha = WebCall.Post(captchaForm, Proxy);

			// todo: Нужно обработать капчу

			return EndAuthorize(captcha, Proxy);
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
	}
}