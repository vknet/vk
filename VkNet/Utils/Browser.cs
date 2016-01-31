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
        /// Адрес хоста
        /// </summary>
        private string _host;
        /// <summary>
        /// Порт
        /// </summary>
        private int? _port;

        /// <summary>
        /// Получение json по url-адресу
        /// </summary>
        /// <param name="url">Адрес получения json</param>
        /// <returns>Строка в формате json</returns>
        public string GetJson(string url)
        {
            var separatorPosition = url.IndexOf('?');
            var methodUrl = separatorPosition < 0 ? url : url.Substring(0, separatorPosition);
            var parameters = separatorPosition < 0 ? string.Empty : url.Substring(separatorPosition + 1);

            return WebCall.PostCall(methodUrl, parameters, _host, _port).Response;
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
        /// <param name="code">Код двухфакторной авторизации</param>
        /// <param name="captchaSid">Идентификатор капчи</param>
        /// <param name="captchaKey">Текст капчи</param>
        /// <param name="host">Имя узла прокси-сервера.</param>
        /// <param name="port">Номер порта используемого Host.</param>
        /// <returns>Информация об авторизации приложения</returns>
        public VkAuthorization Authorize(ulong appId, string email, string password, Settings settings, Func<string> code = null, long? captchaSid = null, string captchaKey = null,
                                         string host = null, int? port = null)
        {
            _host = string.IsNullOrWhiteSpace(host) ? null : host;
            _port = port;

            var authorizeUrl = CreateAuthorizeUrlFor(appId, settings, Display.Wap);
            var authorizeUrlResult = WebCall.MakeCall(authorizeUrl, host, port);

            // Заполнить логин и пароль
            var loginForm = WebForm.From(authorizeUrlResult).WithField("email").FilledWith(email).And().WithField("pass").FilledWith(password);
            if (captchaSid.HasValue)
                loginForm.WithField("captcha_sid").FilledWith(captchaSid.Value.ToString()).WithField("captcha_key").FilledWith(captchaKey);
            var loginFormPostResult = WebCall.Post(loginForm, host, port);

            // Заполнить код двухфакторной авторизации
            if (code != null)
            {
                var codeForm = WebForm.From(loginFormPostResult).WithField("code").FilledWith(code());
                loginFormPostResult = WebCall.Post(codeForm, host, port);
            }

            var authorization = VkAuthorization.From(loginFormPostResult.ResponseUrl);
            if (authorization.CaptchaID.HasValue)
                throw new CaptchaNeededException(authorization.CaptchaID.Value, "http://api.vk.com/captcha.php?sid=" + authorization.CaptchaID.Value.ToString());
            if (!authorization.IsAuthorizationRequired)
                return authorization;

            // Отправить данные
            var authorizationForm = WebForm.From(loginFormPostResult);
            var authorizationFormPostResult = WebCall.Post(authorizationForm, host, port);

            return VkAuthorization.From(authorizationFormPostResult.ResponseUrl);
        }

        /// <summary>
        /// Построить URL для авторизации.
        /// </summary>
        /// <param name="appId">Идентификатор приложения.</param>
        /// <param name="settings">Настройки прав доступа.</param>
        /// <param name="display">Вид окна авторизации.</param>
        /// <returns></returns>
        internal static string CreateAuthorizeUrlFor(ulong appId, Settings settings, Display display)
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