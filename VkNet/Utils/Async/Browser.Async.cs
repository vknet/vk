using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using JetBrains.Annotations;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Exception;
using VkNet.Model;

namespace VkNet.Utils
{
    /// <summary>
    /// Браузер
    /// </summary>
    public partial class Browser
    {
        /// <summary>
        /// Асинхронное получение json по url-адресу
        /// </summary>
        /// <param name="methodUrl">Адрес получения json</param>
        /// <param name="parameters">Параметры метода api</param>
        /// <returns>Строка в формате json</returns>
        public async Task<string> GetJsonAsync(string methodUrl, IEnumerable<KeyValuePair<string, string>> parameters)
        {
            return (await WebCall.PostCallAsync(methodUrl, parameters, Proxy)).Response;
        }

        /// <summary>
        /// Асинхронная авторизация на сервере ВК
        /// </summary>
        /// <param name="authParams">Параметры авторизации</param>
        /// <returns>Информация об авторизации приложения</returns>
        public async Task<VkAuthorization> AuthorizeAsync(IApiAuthParams authParams)
        {
            _logger?.Debug("Шаг 1. Открытие диалога авторизации");
            var authorizeUrlResult = await OpenAuthDialogAsync(authParams.ApplicationId, authParams.Settings);

            if (IsAuthSuccessfull(authorizeUrlResult))
            {
                return await EndAuthorizeAsync(authorizeUrlResult, Proxy);
            }

            _logger?.Debug("Шаг 2. Заполнение формы логина");
            var loginFormPostResult = await FilledLoginFormAsync(authParams.Login, authParams.Password,
                authParams.CaptchaSid, authParams.CaptchaKey, authorizeUrlResult);

            if (IsAuthSuccessfull(loginFormPostResult))
            {
                return await EndAuthorizeAsync(loginFormPostResult, Proxy);
            }

            if (HasNotTwoFactor(authParams.TwoFactorAuthorization, loginFormPostResult))
            {
                return await EndAuthorizeAsync(loginFormPostResult, Proxy);
            }

            _logger?.Debug("Шаг 2.5.1. Заполнить код двухфакторной авторизации");
            var twoFactorFormResult = await FilledTwoFactorFormAsync(authParams.TwoFactorAuthorization, loginFormPostResult);
            if (IsAuthSuccessfull(twoFactorFormResult))
            {
                return await EndAuthorizeAsync(twoFactorFormResult, Proxy);
            }

            _logger?.Debug("Шаг 2.5.2 Капча");
            var captchaForm = WebForm.From(twoFactorFormResult);

            var captcha = await WebCall.PostAsync(captchaForm, Proxy);
            // todo: Нужно обработать капчу

            return await EndAuthorizeAsync(captcha, Proxy);
        }

        /// <summary>
        /// Заполнить форму двухфакторной авторизации асинхронно
        /// </summary>
        /// <param name="code">Функция возвращающая код двухфакторной авторизации</param>
        /// <param name="loginFormPostResult">Ответ сервера vk</param>
        /// <returns>Ответ сервера vk</returns>
        private async Task<WebCallResult> FilledTwoFactorFormAsync(Func<string> code, WebCallResult loginFormPostResult)
        {
            var codeForm = WebForm.From(loginFormPostResult)
                .WithField("code")
                .FilledWith(code.Invoke());

            return await WebCall.PostAsync(codeForm, Proxy);
        }

        /// <summary>
        /// Заполнить форму логин и пароль асинхронно
        /// </summary>
        /// <param name="email">Логин</param>
        /// <param name="password">Пароль</param>
        /// <param name="captchaSid">ИД капчи</param>
        /// <param name="captchaKey">Значение капчи</param>
        /// <param name="authorizeUrlResult"></param>
        /// <returns></returns>
        private async Task<WebCallResult> FilledLoginFormAsync(string email, string password, long? captchaSid, string captchaKey,
            WebCallResult authorizeUrlResult)
        {
            var loginForm = WebForm.From(authorizeUrlResult)
                .WithField("email")
                .FilledWith(email)
                .And()
                .WithField("pass")
                .FilledWith(password);

            if (captchaSid.HasValue)
            {
                _logger?.Debug("Шаг 2. Заполнение формы логина. Капча");
                loginForm.WithField("captcha_sid")
                    .FilledWith(captchaSid.Value.ToString())
                    .WithField("captcha_key")
                    .FilledWith(captchaKey);
            }

            return await WebCall.PostAsync(loginForm, Proxy);
        }

        /// <summary>
        /// Выполняет обход ошибки валидации асинхронно: https://vk.com/dev/need_validation
        /// </summary>
        /// <param name="validateUrl">Адрес страницы валидации</param>
        /// <param name="phoneNumber">Номер телефона, который необходимо ввести на странице валидации</param>
        /// <returns>Информация об авторизации приложения.</returns>
        public async Task<VkAuthorization> ValidateAsync(string validateUrl, string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(validateUrl))
            {
                throw new ArgumentException("Не задан адрес валидации!");
            }

            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                throw new ArgumentException("Не задан номер телефона!");
            }

            var validateUrlResult = await WebCall.MakeCallAsync(validateUrl, Proxy);
            var codeForm = WebForm.From(validateUrlResult)
                .WithField("code")
                .FilledWith(phoneNumber.Substring(1, 8));
            var codeFormPostResult = await WebCall.PostAsync(codeForm, Proxy);

            return await EndAuthorizeAsync(codeFormPostResult, Proxy);
        }

        /// <summary>
        /// Закончить авторизацию асинхронно
        /// </summary>
        /// <param name="result">Результат</param>
        /// <param name="webProxy">Настройки прокси</param>
        /// <returns></returns>
        /// <exception cref="CaptchaNeededException"></exception>
        private async Task<VkAuthorization> EndAuthorizeAsync(WebCallResult result, IWebProxy webProxy = null)
        {
            if (IsAuthSuccessfull(result))
            {
                var auth = GetTokenUri(result);
                return VkAuthorization.From(auth.ToString());
            }

            if (HasСonfirmationRights(result))
            {
                _logger?.Debug("Требуется подтверждение прав");
                var authorizationForm = WebForm.From(result);
                var authorizationFormPostResult = await WebCall.PostAsync(authorizationForm, webProxy);

                if (!IsAuthSuccessfull(authorizationFormPostResult))
                {
                    throw new VkApiException("URI должен содержать токен!");
                }

                var tokenUri = GetTokenUri(authorizationFormPostResult);
                return VkAuthorization.From(tokenUri.ToString());
            }

            var captchaSid = HasCaptchaInput(result);
            if (!captchaSid.HasValue)
            {
                throw new VkApiException("Непредвиденная ошибка авторизации. Обратитесь к разработчику.");
            }

            _logger?.Debug("Требуется ввод капчи");
            throw new VkApiException("Требуется ввод капчи");
        }

        /// <summary>
        /// Открытие окна авторизацииасинхронно 
        /// </summary>
        /// <param name="appId">id приложения</param>
        /// <param name="settings">Настройки приложения</param>
        /// <returns></returns>
        private async Task<WebCallResult> OpenAuthDialogAsync(ulong appId, [NotNull] Settings settings)
        {
            var url = CreateAuthorizeUrlFor(appId, settings, Display.Page);
            return await WebCall.MakeCallAsync(url, Proxy);
        }
    }
}
