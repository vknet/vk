namespace VkToolkit.Utils
{
    using System.Text;

    using VkToolkit.Enums;

    public class Browser : IBrowser
    {
        public string GetJson(string url)
        {
            return WebCall.MakeCall(url).Response;
        }

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