using System;
using System.Net;

namespace VkNet.UWP.Utils
{
    /// <summary>
    /// Реализация WebProxy
    /// </summary>
    public class WebProxy : IWebProxy
    {
        /// <summary>
        /// Данные авторизации
        /// </summary>
        public ICredentials Credentials { get; set; }

        /// <summary>
        /// Uri прокси
        /// </summary>
        private readonly Uri _proxyUri;

        /// <summary>
        /// Инициализация класса прокси
        /// </summary>
        /// <param name="proxyUri">Uri прокси</param>
        private WebProxy(Uri proxyUri)
        {
            _proxyUri = proxyUri;
        }
        /// <summary>
        /// Получить прокси
        /// </summary>
        /// <param name="destination">Uri назначения</param>
        /// <returns>Uri прокси</returns>
        public Uri GetProxy(Uri destination) => _proxyUri;

        /// <summary>
        /// Пренебрегать
        /// </summary>
        /// <param name="host">Хост</param>
        /// <returns>Пренебрегать?</returns>
        public bool IsBypassed(Uri host) => false;

        /// <summary>
        /// Получить данные авторизации
        /// </summary>
        /// <param name="proxyLogin">Логин</param>
        /// <param name="proxyPassword">Пароль</param>
        /// <returns>Данные авторизации</returns>
        private static ICredentials GetCredentials(string proxyLogin = null, string proxyPassword = null)
        {
            if (proxyLogin != null && proxyPassword != null)
            {
                return new NetworkCredential(proxyLogin, proxyPassword);
            }
            // Авторизация с реквизитами по умолчанию (для NTLM прокси)
            return CredentialCache.DefaultCredentials;
        }

        /// <summary>
        /// Получить прокси
        /// </summary>
        /// <param name="host">Uri</param>
        /// <param name="port">Порт</param>
        /// <param name="proxyLogin">Логин</param>
        /// <param name="proxyPassword">Пароль</param>
        /// <returns>Прокси</returns>
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