namespace VkNet.Utils
{
    using System.Net;
    using System.Text;

    using VkNet.Enums;

    /// <summary>
    /// Браузер, через который производится сетевое взаимодействие с ВКонтакте.
    /// Сетевое взаимодействие выполняется с помощью <see cref="HttpWebRequest"/>. 
    /// </summary>
    public class Browser : IBrowser
    {
        /// <summary>
        /// Выполняет JSON-запрос к ВКонтакте.
        /// </summary>
        /// <param name="url">URL, в котором закодированы параметры запроса.</param>
        /// <returns>Результат выполнения запроса, полученный от сервера в формате JSON.</returns>
        public string GetJson(string url)
        {
            var separatorPosition = url.IndexOf('?');
            string methodUrl = separatorPosition < 0 ? url : url.Substring(0, separatorPosition);
            string parameters = separatorPosition < 0 ? string.Empty : url.Substring(separatorPosition + 1);

            return WebCall.PostCall(methodUrl, parameters).Response;
        }

        /// <summary>
        /// Выполняет авторизацию ВКонтакте. 
        /// Если приложение с идентификатором <paramref name="appId"/> не было установлено у пользователя, имеющего 
        /// логин <paramref name="email"/>, то производится его установка с разрешениями <paramref name="settings"/>.
        /// </summary>
        /// <param name="appId">Идентификатор авторизуемого приложения.</param>
        /// <param name="email">Логин пользователя ВКонтакте (его почта).</param>
        /// <param name="password">Пароль пользователя.</param>
        /// <param name="settings">Запрашиваемые для работы разрешения.</param>
        /// <returns>
        /// Информация об авторизации приложения.
        /// </returns>
        public VkAuthorization Authorize(int appId, string email, string password, Settings settings)
        {
            var authorizeUrl = CreateAuthorizeUrlFor(appId, settings, Display.Wap);
            var authorizeUrlResult = WebCall.MakeCall(authorizeUrl);

            var loginForm = WebForm.From(authorizeUrlResult).WithField("email").FilledWith(email).And().WithField("pass").FilledWith(password);
            var loginFormPostResult = WebCall.Post(loginForm);

            var authorization = VkAuthorization.From(loginFormPostResult.ResponseUrl);
            if (!authorization.IsAuthorizationRequired)
                return authorization;

            var authorizationForm = WebForm.From(loginFormPostResult);
            var authorizationFormPostResult = WebCall.Post(authorizationForm);
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