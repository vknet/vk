using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using VkNet.Exception;
using VkNet.Infrastructure.Authorization.ImplicitFlow;
using VkNet.Model;

// ReSharper disable once CheckNamespace
namespace VkNet.Utils
{
	/// <inheritdoc />
	public partial class Browser
	{
		/// <inheritdoc />
		public async Task<AuthorizationResult> AuthorizeAsync()
		{
			LoginPasswordError = 0;
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
			var result = await _restClient.GetAsync(new Uri(methodUrl), parameters, Encoding.GetEncoding(1251)).ConfigureAwait(false);

			return result.Value;
		}

		/// <summary>
		/// Заполнить форму двухфакторной авторизации асинхронно
		/// </summary>
		/// <param name="code"> Функция возвращающая код двухфакторной авторизации </param>
		/// <param name="loginFormPostResult"> Ответ сервера vk </param>
		/// <returns> Ответ сервера vk </returns>
		private Task<HttpResponse<string>> FilledTwoFactorFormAsync(Func<string> code, HttpResponse<string> loginFormPostResult)
		{
			var codeForm = WebForm.From(loginFormPostResult)
								  .WithField("code")
								  .FilledWith(code.Invoke());

			return _restClient.PostAsync(new Uri(codeForm.ActionUrl), codeForm.GetFormFields(), Encoding.GetEncoding(1251));
		}

		private Task<HttpResponse<string>> FilledConsentAsync(HttpResponse<string> loginFormPostResult)
		{
			var form = WebForm.From(loginFormPostResult);

			return _restClient.PostAsync(new Uri(form.ActionUrl), form.GetFormFields(), Encoding.GetEncoding(1251));
		}

		/// <summary>
		/// Заполнить форму логин и пароль асинхронно
		/// </summary>
		/// <param name="email"> Логин </param>
		/// <param name="password"> Пароль </param>
		/// <param name="authorizeUrlResult"> </param>
		/// <returns> </returns>
		private Task<HttpResponse<string>> FilledLoginFormAsync(string email, string password, HttpResponse<string> authorizeUrlResult)
		{
			var loginForm = WebForm.From(authorizeUrlResult)
								   .WithField("email")
								   .FilledWith(email)
								   .And()
								   .WithField("pass")
								   .FilledWith(password);

			return _restClient.PostAsync(new Uri(loginForm.ActionUrl), loginForm.GetFormFields(), Encoding.GetEncoding(1251));
		}

		/// <summary>
		/// Заполнить форму логин и пароль
		/// </summary>
		/// <param name="email"> Логин </param>
		/// <param name="password"> Пароль </param>
		/// <param name="authorizeUrlResult"> </param>
		/// <returns> </returns>
		private Task<HttpResponse<string>> FilledCaptchaLoginFormAsync(string email, string password, HttpResponse<string> authorizeUrlResult)
		{
			var loginForm = WebForm.From(authorizeUrlResult)
								   .WithField("email")
								   .FilledWith(email)
								   .And()
								   .WithField("pass")
								   .FilledWith(password);

			_logger?.LogDebug("Шаг 2. Заполнение формы логина. Капча");

			var captchaKey =
				_captchaSolver.Solve($"https://api.vk.com/captcha.php?sid={loginForm.GetFieldValue(AuthorizationFormFields.CaptchaSid)}&s=1");

			loginForm.WithField("captcha_key")
					 .FilledWith(captchaKey);

			return _restClient.PostAsync(new Uri(loginForm.ActionUrl), loginForm.GetFormFields(), Encoding.GetEncoding(1251));
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
			if (string.IsNullOrWhiteSpace(validateUrl))
			{
				throw new ArgumentException("Не задан адрес валидации!");
			}

			if (string.IsNullOrWhiteSpace(phoneNumber))
			{
				throw new ArgumentException("Не задан номер телефона!");
			}

			return ValidateInternalAsync(validateUrl, phoneNumber);
		}

		private async Task<VkAuthorization2> ValidateInternalAsync(string validateUrl, string phoneNumber)
		{
			var validateUrlResult = await _restClient.GetAsync(new Uri(validateUrl), Enumerable.Empty<KeyValuePair<string, string>>(), Encoding.GetEncoding(1251));

			var codeForm = WebForm.From(validateUrlResult)
								  .WithField("code")
								  .FilledWith(phoneNumber.Substring(1, 8));

			var codeFormPostResult = await _restClient.PostAsync(new Uri(codeForm.ActionUrl), codeForm.GetFormFields(), Encoding.GetEncoding(1251)).ConfigureAwait(false);

			return await EndAuthorizeAsync(codeFormPostResult).ConfigureAwait(false);
		}

		/// <summary>
		/// Закончить авторизацию асинхронно
		/// </summary>
		/// <param name="result"> Результат </param>
		/// <returns> </returns>
		/// <exception cref="CaptchaNeededException"> </exception>
		private async Task<VkAuthorization2> EndAuthorizeAsync(HttpResponse<string> result)
		{
			if (IsAuthSuccessful(result))
			{
				var auth = GetTokenUri(result);

				return VkAuthorization2.From(auth.ToString());
			}

			if (HasConfirmationRights(result))
			{
				_logger?.LogDebug("Требуется подтверждение прав");
				var authorizationForm = WebForm.From(result);

				var authorizationFormPostResult =
					await _restClient.PostAsync(new Uri(authorizationForm.ActionUrl), authorizationForm.GetFormFields(), Encoding.GetEncoding(1251)).ConfigureAwait(false);

				if (!IsAuthSuccessful(authorizationFormPostResult))
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

			throw new VkApiException("Требуется ввод капчи");
		}

		/// <summary>
		/// Открытие окна авторизации асинхронно
		/// </summary>
		/// <returns> </returns>
		private Task<HttpResponse<string>> OpenAuthDialogAsync()
		{
			var url = CreateAuthorizeUrl();

			return _restClient.GetAsync(url, Enumerable.Empty<KeyValuePair<string, string>>(), Encoding.GetEncoding(1251));
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

			var validateUrlResult =
				await _restClient.GetAsync(new Uri(validateUrl), Enumerable.Empty<KeyValuePair<string, string>>(), Encoding.GetEncoding(1251)).ConfigureAwait(false);

			var codeForm = WebForm.From(validateUrlResult)
								  .WithField("code")
								  .FilledWith(phoneNumber.Substring(1, 8));

			var codeFormPostResult = await _restClient.PostAsync(new Uri(codeForm.ActionUrl), codeForm.GetFormFields(), Encoding.GetEncoding(1251)).ConfigureAwait(false);

			return await EndAuthorizeAsync(codeFormPostResult).ConfigureAwait(false);
		}

		private async Task<AuthorizationResult> NextStepAsync(HttpResponse<string> formResult)
		{
			var pageType = _vkAuthorization.GetPageType(formResult.ResponseUri);
			HttpResponse<string> resultForm = null;

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
					return _vkAuthorization.GetAuthorizationResult(formResult.ResponseUri);
				}
			}

			return await NextStepAsync(resultForm).ConfigureAwait(false);
		}
	}
}