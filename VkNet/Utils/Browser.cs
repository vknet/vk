using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using VkNet.Abstractions;
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

		private IApiAuthParams _authParams;

		/// <summary>
		/// Менеджер версий VkApi
		/// </summary>
		private readonly IVkApiVersionManager _versionManager;

		/// <inheritdoc />
		public Browser([CanBeNull]
						ILogger<Browser> logger, IVkApiVersionManager versionManager)
		{
			_logger = logger;
			_versionManager = versionManager;
		}

		/// <inheritdoc />
		public void SetAuthParams(IApiAuthParams authParams)
		{
			_authParams = authParams;
		}

		/// <inheritdoc />
		public IWebProxy Proxy { get; set; }

		/// <inheritdoc />
		public string GetJson(string url, IEnumerable<KeyValuePair<string, string>> parameters)
		{
			return WebCall.PostCall(url: url, parameters: parameters, webProxy: Proxy).Response;
		}

		/// <inheritdoc />
		public AuthorizationResult Authorize()
		{
			var result = Authorize(_authParams);

			return new AuthorizationResult
			{
				AccessToken = result.AccessToken,
				ExpiresIn = result.ExpiresIn,
				UserId = result.UserId,
				State = result.State
			};
		}

		/// <inheritdoc />
		public Uri CreateAuthorizeUrl(ulong clientId, ulong scope, Display display, string state)
		{
			var builder = new StringBuilder(value: "https://oauth.vk.com/authorize?");

			builder.Append(value: $"client_id={clientId}&");
			builder.Append(value: "redirect_uri=https://oauth.vk.com/blank.html&");
			builder.Append(value: $"display={display}&");
			builder.Append(value: $"scope={scope}&");
			builder.Append(value: "response_type=token&");
			builder.Append(value: $"v={_versionManager.Version}&");
			builder.Append(value: $"state={state}&");
			builder.Append(value: "revoke=1");

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

		/// <summary>
		/// Заполнить форму двухфакторной авторизации
		/// </summary>
		/// <param name="code"> Функция возвращающая код двухфакторной авторизации </param>
		/// <param name="loginFormPostResult"> Ответ сервера vk </param>
		/// <returns> Ответ сервера vk </returns>
		private WebCallResult FilledTwoFactorForm(Func<string> code, WebCallResult loginFormPostResult)
		{
			var codeForm = WebForm.From(result: loginFormPostResult)
				.WithField(name: "code")
				.FilledWith(value: code.Invoke());

			return WebCall.Post(form: codeForm, webProxy: Proxy);
		}

		/// <summary>
		/// Проверка наличия двухфакторной авторизации
		/// </summary>
		/// <param name="code"> Функция возвращающая код двухфакторной авторизации </param>
		/// <param name="loginFormPostResult"> Ответ сервера vk </param>
		/// <returns> </returns>
		private bool HasNotTwoFactor(Func<string> code, WebCallResult loginFormPostResult)
		{
			_logger?.LogDebug(message: "Проверка наличия двухфакторной авторизации");

			return code == null || WebForm.IsOAuthBlank(result: loginFormPostResult);
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
			var loginForm = WebForm.From(result: authorizeUrlResult)
				.WithField(name: "email")
				.FilledWith(value: email)
				.And()
				.WithField(name: "pass")
				.FilledWith(value: password);

			if (!captchaSid.HasValue)
			{
				return WebCall.Post(form: loginForm, webProxy: Proxy);
			}

			_logger?.LogDebug(message: "Шаг 2. Заполнение формы логина. Капча");

			loginForm.WithField(name: "captcha_sid")
				.FilledWith(value: captchaSid.Value.ToString())
				.WithField(name: "captcha_key")
				.FilledWith(value: captchaKey);

			return WebCall.Post(form: loginForm, webProxy: Proxy);
		}

		/// <summary>
		/// Закончить авторизацию
		/// </summary>
		/// <param name="result"> Результат </param>
		/// <param name="webProxy"> Настройки прокси </param>
		/// <returns> </returns>
		/// <exception cref="CaptchaNeededException"> </exception>
		private VkAuthorization EndAuthorize(WebCallResult result, IWebProxy webProxy = null)
		{
			if (IsAuthSuccessfull(webCallResult: result))
			{
				var auth = GetTokenUri(webCallResult: result);

				return VkAuthorization.From(uriFragment: auth.ToString());
			}

			if (HasСonfirmationRights(result: result))
			{
				_logger?.LogDebug(message: "Требуется подтверждение прав");
				var authorizationForm = WebForm.From(result: result);
				var authorizationFormPostResult = WebCall.Post(form: authorizationForm, webProxy: webProxy);

				if (!IsAuthSuccessfull(webCallResult: authorizationFormPostResult))
				{
					throw new VkApiException(message: "URI должен содержать токен!");
				}

				var tokenUri = GetTokenUri(webCallResult: authorizationFormPostResult);

				return VkAuthorization.From(uriFragment: tokenUri.ToString());
			}

			var captchaSid = HasCaptchaInput(result: result);

			if (!captchaSid.HasValue)
			{
				throw new VkApiException(message: "Непредвиденная ошибка авторизации. Обратитесь к разработчику.");
			}

			_logger?.LogDebug(message: "Требуется ввод капчи");

			throw new CaptchaNeededException(sid: captchaSid.Value, img: "https://m.vk.com/captcha.php?sid=" + captchaSid.Value);
		}

		private bool HasСonfirmationRights(WebCallResult result)
		{
			var request = VkAuthorization.From(uriFragment: result.RequestUrl.ToString());
			var response = VkAuthorization.From(uriFragment: result.ResponseUrl.ToString());

			return request.IsAuthorizationRequired || response.IsAuthorizationRequired;
		}

		private long? HasCaptchaInput(WebCallResult result)
		{
			var request = VkAuthorization.From(uriFragment: result.RequestUrl.ToString());
			var response = VkAuthorization.From(uriFragment: result.ResponseUrl.ToString());

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
		private WebCallResult OpenAuthDialog(ulong appId, [NotNull]
											Settings settings)
		{
			var url = CreateAuthorizeUrl(appId, settings.ToUInt64(), Display.Page, "123456");

			return WebCall.MakeCall(url: url.ToString(), webProxy: Proxy);
		}

		/// <summary>
		/// Авторизация прошла успешно
		/// </summary>
		/// <param name="webCallResult"> </param>
		/// <returns> true, если авторизация прошла успешно </returns>
		private static bool IsAuthSuccessfull(WebCallResult webCallResult)
		{
			return UriHasAccessToken(uri: webCallResult.RequestUrl) || UriHasAccessToken(uri: webCallResult.ResponseUrl);
		}

		/// <summary>
		/// Проверка наличия токена в url
		/// </summary>
		/// <param name="uri"> </param>
		/// <returns> </returns>
		private static bool UriHasAccessToken(Uri uri)
		{
			return uri.Fragment
				.StartsWith(value: "#access_token=", comparisonType: StringComparison.Ordinal);
		}

		/// <summary>
		/// Получить токен из uri
		/// </summary>
		/// <param name="webCallResult"> Результат запроса </param>
		/// <returns> Возвращает uri содержащий токен </returns>
		/// <exception cref="VkApiException"> URI должен содержать токен! </exception>
		private Uri GetTokenUri(WebCallResult webCallResult)
		{
			if (UriHasAccessToken(uri: webCallResult.RequestUrl))
			{
				_logger?.LogDebug(message: "Запрос: " + webCallResult.RequestUrl);

				return webCallResult.RequestUrl;
			}

			if (UriHasAccessToken(uri: webCallResult.ResponseUrl))
			{
				_logger?.LogDebug(message: "Ответ: " + webCallResult.ResponseUrl);

				return webCallResult.ResponseUrl;
			}

			return null;
		}

		private VkAuthorization Authorize(IApiAuthParams authParams)
		{
			_logger?.LogDebug(message: "Шаг 1. Открытие диалога авторизации");
			var authorizeUrlResult = OpenAuthDialog(appId: authParams.ApplicationId, settings: authParams.Settings);

			if (IsAuthSuccessfull(webCallResult: authorizeUrlResult))
			{
				return EndAuthorize(result: authorizeUrlResult, webProxy: Proxy);
			}

			_logger?.LogDebug(message: "Шаг 2. Заполнение формы логина");

			var loginFormPostResult = FilledLoginForm(email: authParams.Login,
				password: authParams.Password,
				captchaSid: authParams.CaptchaSid,
				captchaKey: authParams.CaptchaKey,
				authorizeUrlResult: authorizeUrlResult);

			if (IsAuthSuccessfull(webCallResult: loginFormPostResult))
			{
				return EndAuthorize(result: loginFormPostResult, webProxy: Proxy);
			}

			if (HasNotTwoFactor(code: authParams.TwoFactorAuthorization, loginFormPostResult: loginFormPostResult))
			{
				return EndAuthorize(result: loginFormPostResult, webProxy: Proxy);
			}

			_logger?.LogDebug(message: "Шаг 2.5.1. Заполнить код двухфакторной авторизации");

			var twoFactorFormResult =
				FilledTwoFactorForm(code: authParams.TwoFactorAuthorization, loginFormPostResult: loginFormPostResult);

			if (IsAuthSuccessfull(webCallResult: twoFactorFormResult))
			{
				return EndAuthorize(result: twoFactorFormResult, webProxy: Proxy);
			}

			_logger?.LogDebug(message: "Шаг 2.5.2 Капча");
			var captchaForm = WebForm.From(result: twoFactorFormResult);

			var captcha = WebCall.Post(form: captchaForm, webProxy: Proxy);

			// todo: Нужно обработать капчу

			return EndAuthorize(result: captcha, webProxy: Proxy);
		}

		private VkAuthorization OldValidate(string validateUrl, string phoneNumber)
		{
			if (string.IsNullOrWhiteSpace(value: validateUrl))
			{
				throw new ArgumentException(message: "Не задан адрес валидации!");
			}

			if (string.IsNullOrWhiteSpace(value: phoneNumber))
			{
				throw new ArgumentException(message: "Не задан номер телефона!");
			}

			var validateUrlResult = WebCall.MakeCall(url: validateUrl, webProxy: Proxy);

			var codeForm = WebForm.From(result: validateUrlResult)
				.WithField(name: "code")
				.FilledWith(value: phoneNumber.Substring(startIndex: 1, length: 8));

			var codeFormPostResult = WebCall.Post(form: codeForm, webProxy: Proxy);

			return EndAuthorize(result: codeFormPostResult, webProxy: Proxy);
		}
	}
}