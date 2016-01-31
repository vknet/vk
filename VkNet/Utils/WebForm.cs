﻿namespace VkNet.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web;

    using HtmlAgilityPack;

    using Exception;

    internal sealed class WebForm
    {
        private readonly HtmlDocument _html;

        private readonly Dictionary<string, string> _inputs;

        private string _lastName;

        private readonly string _originalUrl;

        private readonly string _responceBaseUrl; // if form has relative url

        public Cookies Cookies { get; private set; }

        private WebForm(WebCallResult result)
        {
            Cookies = result.Cookies;
            _originalUrl = result.RequestUrl.OriginalString;

            _html = new HtmlDocument();
            result.LoadResultTo(_html);

            _responceBaseUrl = result.ResponseUrl.GetLeftPart(UriPartial.Authority);

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

            var encodedValue = HttpUtility.UrlEncode(value);
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

                if (formNode.Attributes["action"] == null)
                    return OriginalUrl;

                var link = formNode.Attributes["action"].Value;
                if (!string.IsNullOrEmpty(link) && !link.StartsWith("http")) // relative url
                {
                    link = _responceBaseUrl + link;
                }

                return link; // absolute path
                //return formNode.Attributes["action"] != null ? formNode.Attributes["action"].Value : OriginalUrl;
            }
        }

        public string OriginalUrl
        {
            get { return _originalUrl; }
        }

        public byte[] GetRequest()
        {
            var uri = _inputs.Select(x => string.Format("{0}={1}", x.Key, x.Value)).JoinNonEmpty("&");
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

                var name = nameAttribute != null ? nameAttribute.Value : string.Empty;
                var value = valueAttribute != null ? valueAttribute.Value : string.Empty;

                if (string.IsNullOrEmpty(name))
                    continue;

                inputs.Add(name, HttpUtility.UrlEncode(value));
            }

            return inputs;
        }

        private HtmlNode GetFormNode()
        {
            HtmlNode.ElementsFlags.Remove("form");
            var form = _html.DocumentNode.SelectSingleNode("//form");
            if (form == null)
                throw new VkApiException("Form element not found.");

            return form;
        }
    }
}