using System;
using System.IO;
using System.Net;
using VkToolkit.Exception;
using WatiN.Core;
using WatiN.Core.Constraints;
using WatiN.Core.Exceptions;

namespace VkToolkit.Utils
{
    public class Browser : IBrowser
    {
        private IE _browser;

        private IE Ie
        {
            get { return _browser ?? (_browser = new IE()); }
        }
        
        public Browser()
        {
            
        }

        public Uri Uri
        {
            get { return Ie.Uri; }
        }

        public string GetJson(string url)
        {
            WebRequest request = WebRequest.Create(url);
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

        public void ClearCookies()
        {
            Ie.ClearCookies();
        }

        public void GoTo(string url)
        {
            Ie.GoTo(url);
        }

        public void Close()
        {
            Ie.Close();
        }

        public void Authorize(string email, string password)
        {
            try
            {
                Ie.TextField(Find.ByName("email")).TypeText(email);
                Ie.TextField(Find.ByName("pass")).TypeText(password);
                Ie.Button(Find.ById("install_allow")).Click();
            }
            catch (ElementNotFoundException ex)
            {
                throw new VkApiException("Could not load a page.", ex);
            }
        }

        public TextField TextField(Constraint findBy)
        {
            return Ie.TextField(findBy);
        }

        public Button Button(Constraint findBy)
        {
            return Ie.Button(findBy);
        }

        public bool ContainsText(string text)
        {
            return Ie.ContainsText(text);
        }

        public void GainAccess()
        {
            try
            {
                Ie.Button(Find.ById("install_allow")).Click();
            }
            catch (ElementNotFoundException ex)
            {
                throw new VkApiException("Could not load a page.", ex);
            }
        }
    }
}