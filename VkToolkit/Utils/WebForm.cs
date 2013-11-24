using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Web;

using HtmlAgilityPack;

using VkToolkit.Exception;

namespace VkToolkit.Utils
{
    internal class WebForm 
    {
        private readonly HtmlDocument _html;        
        private readonly Dictionary<string, string> _inputs;
        private string _lastName;
        private readonly string _originalUrl;

        public Cookies Cookies { get; private set; }

        private WebForm(WebCallResult result)
        {
            Cookies = result.Cookies;
            _originalUrl = result.RequestUrl.OriginalString;
            
            _html = new HtmlDocument();
            result.LoadResultTo(_html);

            _inputs = ParseInputs();
        }

        public static WebForm From(WebCallResult result)
        {
            return new WebForm(result);
        }

        public WebForm And()
        {
            return this;
        }

        public WebForm WithField(string name)
        {
            _lastName = name;

            return this;
        }

        public WebForm FilledWith(string value)
        {
            if (string.IsNullOrEmpty(_lastName))
                throw new InvalidOperationException("Field name not set!");

            string encodedValue = HttpUtility.UrlEncode(value);
            if (_inputs.ContainsKey(_lastName))
                _inputs[_lastName] = encodedValue;
            else
                _inputs.Add(_lastName, encodedValue);

            return this;
        }

        public string ActionUrl
        {
            get
            {
                var formNode = GetFormNode();
                return formNode.Attributes["action"] != null ? formNode.Attributes["action"].Value : OriginalUrl;
            }
        }

        public string OriginalUrl
        {
            get { return _originalUrl; }
        }

        public byte[] GetRequest()
        {
            string uri = _inputs.Select(x => string.Format("{0}={1}", x.Key, x.Value)).JoinNonEmpty("&");
            return Encoding.UTF8.GetBytes(uri);
        }

        private Dictionary<string, string> ParseInputs()
        {
            var inputs = new Dictionary<string, string>();
            
            var form = GetFormNode();
            foreach (var node in form.SelectNodes("//input"))
            {
                var nameAttribute = node.Attributes["name"];
                var valueAttribute = node.Attributes["value"];

                string name = nameAttribute != null ? nameAttribute.Value : string.Empty;
                string value = valueAttribute != null ? valueAttribute.Value : string.Empty;

                if (string.IsNullOrEmpty(name))
                    continue;

                inputs.Add(name, HttpUtility.UrlEncode(value));
            }

            return inputs;
        }

        private HtmlNode GetFormNode()
        {
            HtmlNode.ElementsFlags.Remove("form");
            HtmlNode form = _html.DocumentNode.SelectSingleNode("//form");
            if (form == null)
                throw new VkApiException("Form element not found.");

            return form;
        }
    }
}