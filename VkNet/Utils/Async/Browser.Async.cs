using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using VkNet.Exception;
using VkNet.Model;

namespace VkNet.Utils
{
	/// <inheritdoc />
	public partial class Browser
	{
		/// <summary>
		/// Асинхронное получение json по url-адресу
		/// </summary>
		/// <param name="methodUrl"> Адрес получения json </param>
		/// <param name="parameters"> Параметры метода api </param>
		/// <returns> Строка в формате json </returns>
		[UsedImplicitly]
		public async Task<string> GetJsonAsync(string methodUrl, IEnumerable<KeyValuePair<string, string>> parameters)
		{
			var result = await WebCall.PostCallAsync(methodUrl, parameters, Proxy)
				.ConfigureAwait(false);

			return result.Response;
		}

		/// <summary>
		/// Асинхронная авторизация на сервере ВК
		/// </summary>
		/// <param name="authParams"> Параметры авторизации </param>
		/// <returns> Информация об авторизации приложения </returns>
		[UsedImplicitly]
		public async Task<AuthorizationResult> AuthorizeAsync(IApiAuthParams authParams)
		{
			var authorizeUrlResult = await OpenAuthDialogAsync()
				.ConfigureAwait(false);

			return await NextStepAsync(authorizeUrlResult).ConfigureAwait(false);

/*

			var loginFormPostResult = await FilledLoginFormAsync(authParams.Login,
					authParams.Password,
					authParams.CaptchaSid,
					authParams.CaptchaKey,
					authorizeUrlResult)
				.ConfigureAwait(false);

			if (IsAuthSuccessfull(webCallResult: loginFormPostResult))
			{
				return await EndAuthorizeAsync(loginFormPostResult, Proxy).ConfigureAwait(false);
			}

			if (HasNotTwoFactor(authParams.TwoFactorAuthorization, loginFormPostResult))
			{
				return await EndAuthorizeAsync(loginFormPostResult, Proxy).ConfigureAwait(false);
			}

			_logger?.LogDebug(message: "Шаг 2.5.1. Заполнить код двухфакторной авторизации");

			var twoFactorFormResult =
				await FilledTwoFactorFormAsync(authParams.TwoFactorAuthorization, loginFormPostResult).ConfigureAwait(false);

			if (IsAuthSuccessfull(webCallResult: twoFactorFormResult))
			{
				return await EndAuthorizeAsync(twoFactorFormResult, Proxy).ConfigureAwait(false);
			}

			_logger?.LogDebug(message: "Шаг 2.5.2 Капча");
			var captchaForm = WebForm.From(result: twoFactorFormResult);

			var captcha = await WebCall.PostAsync(captchaForm, Proxy).ConfigureAwait(false);

			// todo: Нужно обработать капчу

			return await EndAuthorizeAsync(captcha, Proxy).ConfigureAwait(false);*/
		}

		/// <summary>
		/// Заполнить форму двухфакторной авторизации асинхронно
		/// </summary>
		/// <param name="code"> Функция возвращающая код двухфакторной авторизации </param>
		/// <param name="loginFormPostResult"> Ответ сервера vk </param>
		/// <returns> Ответ сервера vk </returns>
		private Task<WebCallResult> FilledTwoFactorFormAsync(Func<string> code, WebCallResult loginFormPostResult)
		{
			var codeForm = WebForm.From(result: loginFormPostResult)
				.WithField(name: "code")
				.FilledWith(value: code.Invoke());

			var task = WebCall.PostAsync(codeForm, Proxy);
			task.ConfigureAwait(false);

			return task;
		}

		private Task<WebCallResult> FilledConsentAsync(WebCallResult loginFormPostResult)
		{
			var form = WebForm.From(result: loginFormPostResult);

			var task = WebCall.PostAsync(form, Proxy);
			task.ConfigureAwait(false);

			return task;
		}

		private WebCallResult FilledConsent(WebCallResult loginFormPostResult)
		{
			var form = WebForm.From(result: loginFormPostResult);

			return WebCall.Post(form, Proxy);
		}

		/// <summary>
		/// Заполнить форму логин и пароль асинхронно
		/// </summary>
		/// <param name="email"> Логин </param>
		/// <param name="password"> Пароль </param>
		/// <param name="captchaSid"> ИД капчи </param>
		/// <param name="captchaKey"> Значение капчи </param>
		/// <param name="authorizeUrlResult"> </param>
		/// <returns> </returns>
		private Task<WebCallResult> FilledLoginFormAsync(string email
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

			if (captchaSid.HasValue)
			{
				_logger?.LogDebug(message: "Шаг 2. Заполнение формы логина. Капча");

				loginForm.WithField(name: "captcha_sid")
					.FilledWith(value: captchaSid.Value.ToString())
					.WithField(name: "captcha_key")
					.FilledWith(value: captchaKey);
			}

			var task = WebCall.PostAsync(loginForm, Proxy);
			task.ConfigureAwait(false);

			return task;
		}

		/// <summary>
		/// Выполняет обход ошибки валидации асинхронно: https://vk.com/dev/need_validation
		/// </summary>
		/// <param name="validateUrl"> Адрес страницы валидации </param>
		/// <param name="phoneNumber">
		/// Номер телефона, который необходимо ввести на
		/// странице валидации
		/// </param>
		/// <returns> Информация об авторизации приложения. </returns>
		public Task<VkAuthorization2> ValidateAsync(string validateUrl, string phoneNumber)
		{
			if (string.IsNullOrWhiteSpace(value: validateUrl))
			{
				throw new ArgumentException(message: "Не задан адрес валидации!");
			}

			if (string.IsNullOrWhiteSpace(value: phoneNumber))
			{
				throw new ArgumentException(message: "Не задан номер телефона!");
			}

			var task = ValidateInternalAsync(validateUrl, phoneNumber);
			task.ConfigureAwait(false);

			return task;
		}

		private async Task<VkAuthorization2> ValidateInternalAsync(string validateUrl, string phoneNumber)
		{
			var validateUrlResult = await WebCall.MakeCallAsync(validateUrl, Proxy).ConfigureAwait(false);

			var codeForm = WebForm.From(result: validateUrlResult)
				.WithField(name: "code")
				.FilledWith(value: phoneNumber.Substring(1, 8));

			var codeFormPostResult = await WebCall.PostAsync(codeForm, Proxy).ConfigureAwait(false);

			return await EndAuthorizeAsync(codeFormPostResult, Proxy).ConfigureAwait(false);
		}

		/// <summary>
		/// Закончить авторизацию асинхронно
		/// </summary>
		/// <param name="result"> Результат </param>
		/// <param name="webProxy"> Настройки прокси </param>
		/// <returns> </returns>
		/// <exception cref="CaptchaNeededException"> </exception>
		private async Task<VkAuthorization2> EndAuthorizeAsync(WebCallResult result, IWebProxy webProxy = null)
		{
			if (IsAuthSuccessfull(webCallResult: result))
			{
				var auth = GetTokenUri(webCallResult: result);

				return VkAuthorization2.From(uriFragment: auth.ToString());
			}

			if (HasСonfirmationRights(result: result))
			{
				_logger?.LogDebug(message: "Требуется подтверждение прав");
				var authorizationForm = WebForm.From(result: result);

				var authorizationFormPostResult =
					await WebCall.PostAsync(authorizationForm, webProxy).ConfigureAwait(false);

				if (!IsAuthSuccessfull(webCallResult: authorizationFormPostResult))
				{
					throw new VkApiException(message: "URI должен содержать токен!");
				}

				var tokenUri = GetTokenUri(webCallResult: authorizationFormPostResult);

				return VkAuthorization2.From(uriFragment: tokenUri.ToString());
			}

			var captchaSid = HasCaptchaInput(result: result);

			if (!captchaSid.HasValue)
			{
				throw new VkApiException(message: "Непредвиденная ошибка авторизации. Обратитесь к разработчику.");
			}

			_logger?.LogDebug(message: "Требуется ввод капчи");

			throw new VkApiException(message: "Требуется ввод капчи");
		}

		/// <summary>
		/// Открытие окна авторизации асинхронно
		/// </summary>
		/// <returns> </returns>
		private Task<WebCallResult> OpenAuthDialogAsync()
		{
			var url = CreateAuthorizeUrl();

			var task = WebCall.MakeCallAsync(url.ToString(), Proxy);
			task.ConfigureAwait(false);

			return task;
		}
	}
}