namespace VkNet.Utils
{
    using System;
    using System.Net;
    using System.Text;

    using Enums.Filters;
    using Enums.SafetyEnums;
    using Newtonsoft.Json.Linq;

    using Exception;

    /// <summary>
    /// Браузер, через который производится сетевое взаимодействие с ВКонтакте.
    /// Сетевое взаимодействие выполняется с помощью <see cref="HttpWebRequest"/>. 
    /// </summary>
    public class Browser : IBrowser
    {
        /// <summary>
        /// Получение json по url-адресу
        /// </summary>
        /// <param name="url">Адрес получения json</param>
        /// <returns>Строка в формате json</returns>
        public string GetJson(string url)
        {
            var separatorPosition = url.IndexOf('?');
            string methodUrl = separatorPosition < 0 ? url : url.Substring(0, separatorPosition);
            string parameters = separatorPosition < 0 ? string.Empty : url.Substring(separatorPosition + 1);

            return WebCall.PostCall(methodUrl, parameters).Response;
        }

        /// <summary>
        /// Загружает файл на заданный Url
        /// </summary>
        /// <param name="uploadUrl">Адрес для загрузки</param>
        /// <param name="path">Путь к файлу</param>
        /// <returns>Cтрока, используемая далее в Vk API</returns>
        public static string UploadFile(string uploadUrl, string path)
        {
            using (var client = new WebClient())
            {
                var answer = Encoding.UTF8.GetString(client.UploadFile(uploadUrl, path));

                var json = JObject.Parse(answer);

                var rawResponse = json["file"];
                return new VkResponse(rawResponse) { RawJson = answer };
            }
        }

        /// <summary>
        /// Скачивает файл по заданному Url
        /// </summary>
        /// <param name="url">Url для скачки</param>
        /// <param name="path">Путь сохранения файла</param>
        public static void DownloadFile(string url, string path)
        {
            using (var client = new WebClient())
                client.DownloadFile(url, path);
        }

#if false
        /// <summary>
        /// Асинхронное получение json по url-адресу
        /// </summary>
        /// <param name="url">Адрес получения json</param>
        /// <returns>Строка в формате json</returns>
        public async Task<string> GetJsonAsync(string url)
        {
            // todo refactor this shit
            var separatorPosition = url.IndexOf('?');
            string methodUrl = separatorPosition < 0 ? url : url.Substring(0, separatorPosition);
            string parameters = separatorPosition < 0 ? string.Empty : url.Substring(separatorPosition + 1);

            return await WebCall.PostCallAsync(url, parameters);
        }
#endif

        /// <summary>
        /// Авторизация на сервере ВК
        /// </summary>
        /// <param name="appId">Идентификатор приложения</param>
        /// <param name="email">Логин - телефон или эл. почта</param>
        /// <param name="password">Пароль</param>
        /// <param name="settings">Уровень доступа приложения</param>
        /// <param name="captcha_sid">Идентификатор капчи</param>
        /// <param name="captcha_key">Текст капчи</param>
        /// <returns>Информация об авторизации приложения</returns>
        public VkAuthorization Authorize(int appId, string email, string password, Settings settings, Func<string> code = null,  long? captcha_sid = null, string captcha_key = null)
        {
            string authorizeUrl = CreateAuthorizeUrlFor(appId, settings, Display.Wap);
            WebCallResult authorizeUrlResult = WebCall.MakeCall(authorizeUrl);

            // fill email and password
            WebForm loginForm = WebForm.From(authorizeUrlResult).WithField("email").FilledWith(email).And().WithField("pass").FilledWith(password);
            if (captcha_sid.HasValue)
                loginForm.WithField("captcha_sid").FilledWith(captcha_sid.Value.ToString()).WithField("captcha_key").FilledWith(captcha_key);
            WebCallResult loginFormPostResult = WebCall.Post(loginForm);

            // fill code
            if (code != null)
            {
                WebForm codeForm = WebForm.From(loginFormPostResult).WithField("code").FilledWith(code());
                loginFormPostResult = WebCall.Post(codeForm);
            }

            VkAuthorization authorization = VkAuthorization.From(loginFormPostResult.ResponseUrl);
            if (authorization.CaptchaID.HasValue)
                throw new CaptchaNeededException(authorization.CaptchaID.Value, "http://api.vk.com/captcha.php?sid=" + authorization.CaptchaID.Value.ToString());
            if (!authorization.IsAuthorizationRequired)
                return authorization;

            // press allow button
            WebForm authorizationForm = WebForm.From(loginFormPostResult);
            WebCallResult authorizationFormPostResult = WebCall.Post(authorizationForm);

            return VkAuthorization.From(authorizationFormPostResult.ResponseUrl);
        }

        internal static string CreateAuthorizeUrlFor(int appId, Settings settings, Display display)
        {
            var builder = new StringBuilder("https://oauth.vk.com/authorize?");

            builder.AppendFormat("client_id={0}&", appId);
            builder.AppendFormat("scope={0}&", settings);
            builder.Append("redirect_uri=https://oauth.vk.com/blank.html&");
            builder.AppendFormat("display={0}&", display);
            builder.Append("response_type=token");

            return builder.ToString();
        }
    }
}