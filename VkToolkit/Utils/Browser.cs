using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using HtmlAgilityPack;
using VkToolkit.Exception;
#if WINDOWS_PHONE

#else
using System.Web;
#endif

namespace VkToolkit.Utils
{
    public class Browser : IBrowser
    {
        private readonly HtmlDocument _html;
        private readonly CookieContainer _cookies;
        private string _referer;

        public Browser()
        {
            _html = new HtmlDocument();
            _cookies = new CookieContainer();
        }

        public Uri Url { get; private set; }
        
        public string GetJson(string url)
        {
            WebRequest request = WebRequest.Create(new Uri(url));
            WebResponse response;

            try
            {
                response = request.GetResponse();
            }
            catch (WebException ex)
            {
                throw new VkApiException(ex.Message, ex);
            }

            Stream stream = response.GetResponseStream();

            if (stream == null)
                throw new VkApiException("Stream response is null.");

            var sr = new StreamReader(stream);
            return sr.ReadToEnd();
        }
        
        public void GoTo(string url)
        {
            Url = new Uri(url);

            var req = (HttpWebRequest) WebRequest.Create(url);
            HttpWebResponse resp = GetResponse(req);

            _referer = resp.ResponseUri.OriginalString;
            _html.Load(resp.GetResponseStream(), Encoding.UTF8);
        }

        public void Authorize(string email, string password)
        {
            var inputs = new Dictionary<string, string>();
            var form = GetFormNode();
            foreach (HtmlNode node in form.SelectNodes("//input"))
            {
                HtmlAttribute nameAttribute = node.Attributes["name"];
                HtmlAttribute valueAttribute = node.Attributes["value"];

                string name = nameAttribute != null ? nameAttribute.Value : string.Empty;
                string value = valueAttribute != null ? valueAttribute.Value : string.Empty;

                if (string.IsNullOrEmpty(name)) continue;
                if (name == "email") value = email;
                if (name == "pass") value = password;

                inputs.Add(name, HttpUtility.UrlEncode(value));
            }

            string actionUrl = form.Attributes["action"] != null ? form.Attributes["action"].Value : Url.OriginalString;

            string uri = string.Join("&", inputs.Select(x => string.Format("{0}={1}", x.Key, x.Value)));
            byte[] bytes = Encoding.UTF8.GetBytes(uri);

            var req = (HttpWebRequest) WebRequest.Create(actionUrl);
            req.CookieContainer = new CookieContainer();
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = bytes.Length;
            req.GetRequestStream().Write(bytes, 0, bytes.Length);
            req.AllowAutoRedirect = false;

            HttpWebResponse resp = GetResponse(req);
            _html.Load(resp.GetResponseStream(), Encoding.UTF8);
            Url = resp.ResponseUri;
            
            SaveCookies(Url, resp.Cookies);

            if ((int)resp.StatusCode == 302) // redirect
            {
                Redirect(resp.Headers["Location"]);
            }
            //else
            //    throw new VkApiException("Redirect expected!");
        }
        
        public void GainAccess()
        {
            var inputs = new Dictionary<string, string>();
            var form = GetFormNode();

            foreach (HtmlNode node in form.SelectNodes("//input"))
            {
                HtmlAttribute nameAttribute = node.Attributes["name"];
                HtmlAttribute valueAttribute = node.Attributes["value"];

                string name = nameAttribute != null ? nameAttribute.Value : string.Empty;
                string value = valueAttribute != null ? valueAttribute.Value : string.Empty;

                // skip submit button
                if (string.IsNullOrEmpty(name)) continue;
                inputs.Add(name, HttpUtility.UrlEncode(value));
            }

            string actionUrl = form.Attributes["action"] != null ? form.Attributes["action"].Value : Url.OriginalString;

            string uri = string.Join("&", inputs.Select(x => string.Format("{0}={1}", x.Key, x.Value)));
            byte[] bytes = Encoding.UTF8.GetBytes(uri);

            var req = (HttpWebRequest)WebRequest.Create(actionUrl);
            req.Referer = _referer;
            req.CookieContainer = _cookies;
            req.CookieContainer = new CookieContainer();
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = bytes.Length;
            req.GetRequestStream().Write(bytes, 0, bytes.Length);
            req.AllowAutoRedirect = false;

            HttpWebResponse resp = GetResponse(req);
            _html.Load(resp.GetResponseStream(), Encoding.UTF8);
            Url = resp.ResponseUri;

            if ((int)resp.StatusCode == 302) // redirect
            {
                Redirect(resp.Headers["Location"]);
            }
        }

        public bool ContainsText(string text)
        {
            if (_html == null || _html.DocumentNode == null)
                return false;

            HtmlNode bodyNode = _html.DocumentNode.SelectSingleNode("//body");
            if (bodyNode == null)
                return false;

            string body = bodyNode.InnerText;
            return body.Contains(text);
        }

        #region Private Methods

        private void SaveCookies(Uri url, CookieCollection cookies)
        {
            foreach (Cookie c in cookies)
            {
                _cookies.Add(url, c);
            }
        }

        private HttpWebResponse GetResponse(HttpWebRequest req)
        {
            HttpWebResponse resp;
            try
            {
                resp = (HttpWebResponse)req.GetResponse();
            }
            catch (WebException ex)
            {
                throw new VkApiException("Check your internet connection.", ex);
            }

            return resp;
        }
        private void Redirect(string url)
        {
            var req = (HttpWebRequest)WebRequest.Create(url);
            req.CookieContainer = _cookies;
            req.Method = "GET";
            req.ContentType = "text/html";

            HttpWebResponse resp = GetResponse(req);
            
            _html.Load(resp.GetResponseStream(), Encoding.UTF8);
            Url = resp.ResponseUri;
        }

        private HtmlNode GetFormNode()
        {
            HtmlNode.ElementsFlags.Remove("form");
            HtmlNode form = _html.DocumentNode.SelectSingleNode("//form");
            if (form == null)
                throw new VkApiException("Form element not found.");
            return form;
        }
        #endregion
    }
}