using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using VkNet.Enums;
using VkNet.Exception;
using VkNet.Infrastructure.Authorization.ImplicitFlow;
using VkNet.Model;

namespace VkNet.Utils
{
	/// <inheritdoc />
	public partial class Browser
	{
		/// <inheritdoc />
		public async Task<AuthorizationResult> AuthorizeAsync()
		{
			var authorizeUrlResult = await OpenAuthDialogAsync().ConfigureAwait(false);

			return await NextStepAsync(authorizeUrlResult).ConfigureAwait(false);
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
		/// Заполнить форму двухфакторной авторизации асинхронно
		/// </summary>
		/// <param name="code"> Функция возвращающая код двухфакторной авторизации </param>
		/// <param name="loginFormPostResult"> Ответ сервера vk </param>
		/// <returns> Ответ сервера vk </returns>
		private Task<WebCallResult> FilledTwoFactorFormAsync(Func<string> code, WebCallResult loginFormPostResult)
		{
			var codeForm = WebForm.From(loginFormPostResult)
				.WithField("code")
				.FilledWith(code.Invoke());

			var task = WebCall.PostAsync(codeForm, Proxy);
			task.ConfigureAwait(false);

			return task;
		}

		private Task<WebCallResult> FilledConsentAsync(WebCallResult loginFormPostResult)
		{
			var form = WebForm.From(loginFormPostResult);

			var task = WebCall.PostAsync(form, Proxy);
			task.ConfigureAwait(false);

			return task;
		}

		/// <summary>
		/// Заполнить форму логин и пароль асинхронно
		/// </summary>
		/// <param name="email"> Логин </param>
		/// <param name="password"> Пароль </param>
		/// <param name="authorizeUrlResult"> </param>
		/// <returns> </returns>
		private Task<WebCallResult> FilledLoginFormAsync(string email
														, string password
														, WebCallResult authorizeUrlResult)
		{
			var loginForm = WebForm.From(result: authorizeUrlResult)
				.WithField(name: "email")
				.FilledWith(value: email)
				.And()
				.WithField(name: "pass")
				.FilledWith(value: password);

			var task = WebCall.PostAsync(loginForm, Proxy);
			task.ConfigureAwait(false);

			return task;
		}

		/// <summary>
		/// Заполнить форму логин и пароль
		/// </summary>
		/// <param name="email"> Логин </param>
		/// <param name="password"> Пароль </param>
		/// <param name="authorizeUrlResult"> </param>
		/// <returns> </returns>
		private Task<WebCallResult> FilledCaptchaLoginFormAsync(string email, string password, WebCallResult authorizeUrlResult)
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
					$"https://api.vk.com/captcha.php?sid={loginForm.GetFieldValue(AuthorizationFormFields.CaptchaSid)}&s=1");

			loginForm.WithField("captcha_key")
				.FilledWith(captchaKey);

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

					resultForm = await FilledLoginFormAsync(_authParams.Login, _authParams.Password, formResult)
						.ConfigureAwait(false);

					break;
				}

				case ImplicitFlowPageType.Captcha:

				{
					_logger?.LogDebug("Капча.");

					resultForm = await FilledCaptchaLoginFormAsync(_authParams.Login, _authParams.Password, formResult)
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
	}
}