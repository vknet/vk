using System;
using System.Net;

namespace VkNet.UWP.Utils
{
    internal class WebProxy : IWebProxy
    {
        public ICredentials Credentials { get; set; }

        private readonly Uri _proxyUri;

        private WebProxy(Uri proxyUri)
        {
            _proxyUri = proxyUri;
        }

        public Uri GetProxy(Uri destination)
        {
            return _proxyUri;
        }

        public bool IsBypassed(Uri host)
        {
            return false;
        }

        private static ICredentials GetCredentials(string proxyLogin = null, string proxyPassword = null)
        {
            if (proxyLogin != null && proxyPassword != null)
            {
                return new NetworkCredential(proxyLogin, proxyPassword);
            }
            // Авторизация с реквизитами по умолчанию (для NTLM прокси)
            return CredentialCache.DefaultCredentials;
        }

        public static IWebProxy GetProxy(string host = null, int? port = null, string proxyLogin = null, string proxyPassword = null)
        {
            if (host == null || port == null)
            {
                return null;
            }

            var proxyHost = new Uri(host);
            return new WebProxy(new Uri($"{proxyHost.Host}:{port.Value}"))
            {
                Credentials = GetCredentials(proxyLogin, proxyPassword)
            };
        }
    }
}