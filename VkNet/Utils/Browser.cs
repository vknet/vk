using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using NLog;
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
		[CanBeNull] private readonly ILogger _logger;

		/// <inheritdoc />
		public Browser([CanBeNull] ILogger logger)
		{
			_logger = logger;
		}

		/// <inheritdoc />
		public IWebProxy Proxy { get; set; }

		/// <inheritdoc />
		public string GetJson(string url, IEnumerable<KeyValuePair<string, string>> parameters)
		{
			return WebCall.PostCall(url, parameters, Proxy).Response;
		}

		/// <inheritdoc />
		public VkAuthorization Authorize(IApiAuthParams authParams)
		{
			_logger?.Debug("Шаг 1. Открытие диалога авторизации");
			var authorizeUrlResult = OpenAuthDialog(authParams.ApplicationId, authParams.Settings);

			if ( IsAuthSuccessfull(authorizeUrlResult) )
			{
				return EndAuthorize(authorizeUrlResult, Proxy);
			}

			_logger?.Debug("Шаг 2. Заполнение формы логина");

			var loginFormPostResult = FilledLoginForm(authParams.Login, authParams.Password, authParams.CaptchaSid,
				authParams.CaptchaKey, authorizeUrlResult);

			if ( IsAuthSuccessfull(loginFormPostResult) )
			{
				return EndAuthorize(loginFormPostResult, Proxy);
			}

			if ( HasNotTwoFactor(authParams.TwoFactorAuthorization, loginFormPostResult) )
			{
				return EndAuthorize(loginFormPostResult, Proxy);
			}

			_logger?.Debug("Шаг 2.5.1. Заполнить код двухфакторной авторизации");
			var twoFactorFormResult = FilledTwoFactorForm(authParams.TwoFactorAuthorization, loginFormPostResult);

			if ( IsAuthSuccessfull(twoFactorFormResult) )
			{
				return EndAuthorize(twoFactorFormResult, Proxy);
			}

			_logger?.Debug("Шаг 2.5.2 Капча");
			var captchaForm = WebForm.From(twoFactorFormResult);

			var captcha = WebCall.Post(captchaForm, Proxy);

			// todo: Нужно обработать капчу

			return EndAuthorize(captcha, Proxy);
		}

		/// <summary>
		/// Заполнить форму двухфакторной авторизации
		/// </summary>
		/// <param name="code">Функция возвращающая код двухфакторной авторизации</param>
		/// <param name="loginFormPostResult">Ответ сервера vk</param>
		/// <returns>Ответ сервера vk</returns>
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
		/// <param name="code">Функция возвращающая код двухфакторной авторизации</param>
		/// <param name="loginFormPostResult">Ответ сервера vk</param>
		/// <returns></returns>
		private bool HasNotTwoFactor(Func<string> code, WebCallResult loginFormPostResult)
		{
			_logger?.Debug("Проверка наличия двухфакторной авторизации");
			return code == null || WebForm.IsOAuthBlank(loginFormPostResult);
		}

		/// <summary>
		/// Заполнить форму логин и пароль
		/// </summary>
		/// <param name="email">Логин</param>
		/// <param name="password">Пароль</param>
		/// <param name="captchaSid">ИД капчи</param>
		/// <param name="captchaKey">Значение капчи</param>
		/// <param name="authorizeUrlResult"></param>
		/// <returns></returns>
		private WebCallResult FilledLoginForm(string email, string password, long? captchaSid, string captchaKey,
			WebCallResult authorizeUrlResult)
		{
			var loginForm = WebForm.From(authorizeUrlResult)
				.WithField("email")
				.FilledWith(email)
				.And()
				.WithField("pass")
				.FilledWith(password);

			if ( !captchaSid.HasValue )
			{
				return WebCall.Post(loginForm, Proxy);
			}

			_logger?.Debug("Шаг 2. Заполнение формы логина. Капча");

			loginForm.WithField("captcha_sid")
				.FilledWith(captchaSid.Value.ToString())
				.WithField("captcha_key")
				.FilledWith(captchaKey);

			return WebCall.Post(loginForm, Proxy);
		}

		/// <inheritdoc />
		public VkAuthorization Validate(string validateUrl, string phoneNumber)
		{
			if ( string.IsNullOrWhiteSpace(validateUrl) )
			{
				throw new ArgumentException("Не задан адрес валидации!");
			}

			if ( string.IsNullOrWhiteSpace(phoneNumber) )
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

		/// <summary>
		/// Закончить авторизацию
		/// </summary>
		/// <param name="result">Результат</param>
		/// <param name="webProxy">Настройки прокси</param>
		/// <returns></returns>
		/// <exception cref="CaptchaNeededException"></exception>
		private VkAuthorization EndAuthorize(WebCallResult result, IWebProxy webProxy = null)
		{
			if ( IsAuthSuccessfull(result) )
			{
				var auth = GetTokenUri(result);
				return VkAuthorization.From(auth.ToString());
			}

			if ( HasСonfirmationRights(result) )
			{
				_logger?.Debug("Требуется подтверждение прав");
				var authorizationForm = WebForm.From(result);
				var authorizationFormPostResult = WebCall.Post(authorizationForm, webProxy);

				if ( !IsAuthSuccessfull(authorizationFormPostResult) )
				{
					throw new VkApiException("URI должен содержать токен!");
				}

				var tokenUri = GetTokenUri(authorizationFormPostResult);
				return VkAuthorization.From(tokenUri.ToString());
			}

			var captchaSid = HasCaptchaInput(result);

			if ( !captchaSid.HasValue )
			{
				throw new VkApiException("Непредвиденная ошибка авторизации. Обратитесь к разработчику.");
			}

			_logger?.Debug("Требуется ввод капчи");

			throw new CaptchaNeededException(
				captchaSid.Value,
				"https://m.vk.com/captcha.php?sid=" + captchaSid.Value
			);
		}

		private bool HasСonfirmationRights(WebCallResult result)
		{
			var request = VkAuthorization.From(result.RequestUrl.ToString());
			var response = VkAuthorization.From(result.ResponseUrl.ToString());

			return request.IsAuthorizationRequired || response.IsAuthorizationRequired;
		}

		private long? HasCaptchaInput(WebCallResult result)
		{
			var request = VkAuthorization.From(result.RequestUrl.ToString());
			var response = VkAuthorization.From(result.ResponseUrl.ToString());

			if ( request.IsCaptchaNeeded )
			{
				return request.CaptchaSid;
			}

			if ( response.IsCaptchaNeeded )
			{
				return response.CaptchaSid;
			}

			return null;
		}

		/// <summary>
		/// Построить URL для авторизации.
		/// </summary>
		/// <param name="appId">Идентификатор приложения.</param>
		/// <param name="settings">Настройки прав доступа.</param>
		/// <param name="display">Вид окна авторизации.</param>
		/// <returns>Возвращает Uri для авторизации</returns>
		[NotNull]
		private static string CreateAuthorizeUrlFor(ulong appId, [NotNull] Settings settings, [NotNull] Display display)
		{
			var builder = new StringBuilder("https://oauth.vk.com/authorize?");

			builder.AppendFormat("client_id={0}&", appId);
			builder.AppendFormat("scope={0}&", settings.ToUInt64());
			builder.Append("redirect_uri=https://oauth.vk.com/blank.html&");
			builder.AppendFormat("display={0}&", display);
			builder.Append("response_type=token");

			return builder.ToString();
		}

		/// <summary>
		/// Открытие окна авторизации
		/// </summary>
		/// <param name="appId">id приложения</param>
		/// <param name="settings">Настройки приложения</param>
		/// <returns></returns>
		private WebCallResult OpenAuthDialog(ulong appId, [NotNull] Settings settings)
		{
			var url = CreateAuthorizeUrlFor(appId, settings, Display.Page);
			return WebCall.MakeCall(url, Proxy);
		}

		/// <summary>
		/// Авторизация прошла успешно
		/// </summary>
		/// <param name="webCallResult"></param>
		/// <returns>true, если авторизация прошла успешно</returns>
		private static bool IsAuthSuccessfull(WebCallResult webCallResult)
		{
			return UriHasAccessToken(webCallResult.RequestUrl) ||
					UriHasAccessToken(webCallResult.ResponseUrl);
		}

		/// <summary>
		/// Проверка наличия токена в url
		/// </summary>
		/// <param name="uri"></param>
		/// <returns></returns>
		private static bool UriHasAccessToken(Uri uri)
		{
			return uri.Fragment
				.StartsWith("#access_token=", StringComparison.Ordinal);
		}

		/// <summary>
		/// Получить токен из uri
		/// </summary>
		/// <param name="webCallResult">Результат запроса</param>
		/// <returns>Возвращает uri содержащий токен</returns>
		/// <exception cref="VkApiException">URI должен содержать токен!</exception>
		private Uri GetTokenUri(WebCallResult webCallResult)
		{
			if ( UriHasAccessToken(webCallResult.RequestUrl) )
			{
				return webCallResult.RequestUrl;
			}

			_logger?.Debug("Запрос: " + webCallResult.RequestUrl);

			if ( UriHasAccessToken(webCallResult.ResponseUrl) )
			{
				return webCallResult.ResponseUrl;
			}

			_logger?.Debug("Ответ: " + webCallResult.ResponseUrl);
			return null;
		}
	}
}