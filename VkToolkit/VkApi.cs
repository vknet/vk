using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VkToolkit.Enum;
using VkToolkit.Exception;
using VkToolkit.Model;
using VkToolkit.Utils;
using WatiN.Core;
using WatiN.Core.Exceptions;

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
        public int UserId { get; private set; }      // todo string -> int

        public Users Users { get; private set; }

        private const string MethodPrefix = "https://api.vk.com/method/";
        internal IBrowser Browser;

        public VkApi(IBrowser browser = null)
        {
            // set default values
            ResponseType = ResponseType.Json;

            Browser = browser ?? new Utils.Browser(); // undone add test
            
            // set function's categories
            Users = new Users(this);
        }

        [STAThread]
        public void Authorize(int appId, string email, string password)
        {
            Email = email;
            Password = password;
            AppId = appId;

            var browser = new IE();
            browser.ClearCookies();

            string url =
                string.Format(
                    "http://oauth.vk.com/oauth/authorize?client_id={0}&scope=friends&redirect_uri=http://api.vk.com/blank.html&display=popup&response_type=token&_hash=0", appId);
            browser.GoTo(url);

            try
            {
                browser.TextField(Find.ByName("email")).TypeText(email);
                browser.TextField(Find.ByName("pass")).TypeText(password);
                browser.Button(Find.ById("install_allow")).Click();
            }
            catch (ElementNotFoundException ex)
            {
                throw new VkApiException("Could not load a page.", ex);
            }           

            const string invalidLoginOrPassword = "Invalid login or password";
            if (browser.ContainsText(invalidLoginOrPassword))
                throw new VkApiAuthorizationException(invalidLoginOrPassword, email, password);

            if (!browser.ContainsText("Login success"))
                throw new VkApiException();

            // parse values from url
            Uri successUrl = browser.Uri;

            string[] parts = successUrl.Fragment.Split('&');

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
            
            browser.Close();
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

        internal void ThrowExceptionOnServerError(string json)
        {
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

            var errorCode = (int) response["error_code"];
            var message = (string) response["error_msg"];

            switch (errorCode)
            {
                case 5:
                    throw new UserAuthorizationFailException(message);
                    
                default: 
                    throw new VkApiException("Undefined exception");
            }
        }
    }
}
