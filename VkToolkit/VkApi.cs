using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VkToolkit.Categories;
using VkToolkit.Enums;
using VkToolkit.Exception;
using VkToolkit.Utils;

namespace VkToolkit
{
    public class VkApi
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public ResponseType ResponseType { get; set; }
        public int AppId { get; private set; }
        public string SecureKey { get; private set; }
        public string AccessToken { get; internal set; }
        public string ExpiresIn { get; private set; }   // todo string -> int
        public long UserId { get; private set; }      // todo string -> int

        public UsersCategory Users { get; private set; }
        public Friends Friends { get; private set; }
        public StatusCategory Status { get; private set; }
        public MessagesCategory Messages { get; private set; }
        public GroupsCategory Groups { get; private set; }
        public AudioCategory Audio { get; private set; }
        public WallCategory Wall { get; private set; }

        private const string MethodPrefix = "https://api.vk.com/method/";
        internal static string InvalidLoginOrPassword = "Invalid login or password";
        internal static string LoginSuccessed = "Login success";

        internal IBrowser Browser;

        public VkApi()
        {
            // set default values
            ResponseType = ResponseType.Json;
            Browser = new Browser();
            
            // set function's categories
            Users = new UsersCategory(this);
            Friends = new Friends(this);
            Status = new StatusCategory(this);
            Messages = new MessagesCategory(this);
            Groups = new GroupsCategory(this);
            Audio = new AudioCategory(this);
            Wall = new WallCategory(this);
        }

        /// <summary>
        /// Authorize application on vk.com and getting Access Token.
        /// </summary>
        /// <param name="appId">Appliation Id</param>
        /// <param name="email">Email or Phone</param>
        /// <param name="password">Password</param>
        /// <param name="settings">Access rights requested by your application</param>
        /// <param name="display">Type of output page</param>
        /// <param name="isVisible">Is browser window visible?</param>
        [STAThread]
        public void Authorize(int appId, string email, string password, Settings settings, Display display, bool isVisible = true)
        {
            Email = email;
            Password = password;
            AppId = appId;

            string url = CreateAuthorizeUrl(appId, settings, display);

            Browser.Visible = isVisible;
            Browser.ClearCookies();
            Browser.GoTo(url);
            try
            {
                Browser.Authorize(email, password);
            }
            catch (VkApiException)
            {
                Browser.Close();
                throw;
            }

            if (Browser.ContainsText(InvalidLoginOrPassword))
            {
                Browser.Close();
                throw new VkApiAuthorizationException(InvalidLoginOrPassword, email, password);
            }

            // we run our application at first time
            // we need gain access
            if (!Browser.ContainsText(LoginSuccessed))
                Browser.GainAccess();

            if (!Browser.ContainsText(LoginSuccessed))
            {
                Browser.Close();
                throw new VkApiException();
            }

            // parse values from url
            Uri successUrl = Browser.Uri;
            string[] parts = successUrl.Fragment.Split('&');

            // todo IndexOutOfRangeException
            AccessToken = parts[0].Split('=')[1];
            ExpiresIn = parts[1].Split('=')[1];
            try
            {
                UserId = Convert.ToInt32(parts[2].Split('=')[1]);
            }
            catch (FormatException ex)
            {
                UserId = -1;
                throw new VkApiException("UserId is not integer value.", ex);
            }
            finally
            {
                Browser.Close();
            }
        }

        public string GetApiUrl(string method, IDictionary<string, string> values)
        {
            var sb = new StringBuilder();
            sb.AppendFormat("{0}{1}", MethodPrefix, method);
            if (ResponseType == ResponseType.Xml)
                sb.Append(".xml");
            sb.Append("?");

            foreach (var kvp in values)
            {
                sb.AppendFormat("{0}={1}&", kvp.Key, kvp.Value);
            }

            sb.AppendFormat("access_token={0}", AccessToken);
            
            return sb.ToString();
        }

        internal string CreateAuthorizeUrl(int appId, Settings settings, Display display)
        {
            var sb = new StringBuilder("http://oauth.vk.com/authorize?");
            sb.AppendFormat("client_id={0}&", appId);
            sb.AppendFormat("scope={0}&", settings);
            sb.Append("redirect_uri=http://oauth.vk.com/blank.html&");
            sb.AppendFormat("display={0}&", display);
            sb.Append("response_type=token");

            return sb.ToString();
        }

        #region Private & Internal Methods
        internal void IfAccessTokenNotDefinedThrowException()
        {
            if (string.IsNullOrEmpty(AccessToken))
                throw new AccessTokenInvalidException();
        }

        internal void IfErrorThrowException(string json)
        {
            if (string.CompareOrdinal(json.Substring(2, 5), "error") != 0) return;

            JObject obj;
            try
            {
                obj = JObject.Parse(json);
            }
            catch (JsonReaderException ex)
            {
                throw new VkApiException("Wrong json data.", ex);
            }

            var response = obj["error"];

            var code = (int)response["error_code"];
            var message = (string)response["error_msg"];

            switch (code)
            {
                case 5:
                    throw new UserAuthorizationFailException(message, code);

                case 4:     // Incorrect signature.
                case 113:   // Invalid user id.
                case 125:   // Invalid group id.
                case 100:   // One of the parameters specified was missing or invalid.
                    throw new InvalidParamException(message, code);

                case 6:     // Too many requests per second.
                    throw new TooManyRequestsException(message, code);

                case 7:     // Permission to perform this action is denied by user.
                case 15:    // Access denied: groups list of this user are under privacy.
                case 170:   // Access to user's friends list denied.
                case 203:   // Access to the group is denied.
                case 220:   // Access to status denied.
                case 221:   // User disabled track name broadcast.
                case 260:   // Access to the groups list is denied due to the user's privacy settings.
                case 500:   //Permission denied. You must enable votes processing in application settings.
                    throw new AccessDeniedException(message, code);


                case 1:     // Unknown error occurred.
                case 2:     // Application is disabled. Enable your application or use test mode.
                case 10:    // Internal server error.
                case 103:   // Out of limits.
                case 202:
                default:
                    throw new VkApiException(message);
            }
        }
        #endregion
    }
}
