using System;
using System.Collections;
using System.Linq;
using System.Net;
using System.Reflection;

namespace VkNet.Utils
{
    /// <summary>
    /// Cookies
    /// </summary>
    public sealed class Cookies
    {
        /// <summary>
        /// Получить контейнер Cookies.
        /// </summary>
        public CookieContainer Container { get; }

        /// <summary>
        /// Cookies.
        /// </summary>
        public Cookies()
        {
            Container = new CookieContainer();
        }

        /// <summary>
        /// Добавить из.
        /// </summary>
        /// <param name="responseUrl">URL ответа.</param>
        /// <param name="cookies">Cookies.</param>
        public void AddFrom(Uri responseUrl, CookieCollection cookies)
        {
            foreach (Cookie cookie in cookies)
            {
                Container.Add(responseUrl, cookie);
            }

            BugFixCookieDomain();
        }

        /// <summary>
        /// Исправление ошибки в домене указанной куки.
        /// </summary>
        private void BugFixCookieDomain()
        {
            var table = (IDictionary) Container.GetType()
#if NET40
                .InvokeMember("m_domainTable", BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Instance, null, Container, new object[] { });
#else
                .GetRuntimeFields()
                .FirstOrDefault(x => x.Name == "m_domainTable" || x.Name == "_domainTable")
                .GetValue(Container);
#endif

            var keys = table.Keys.OfType<string>().ToList();
            foreach (var key in table.Keys.OfType<string>().ToList())
            {
                if (key[0] != '.')
                {
                    continue;
                }

                var newKey = key.Remove(0, 1);
                if (keys.Contains(newKey))
                {
                    continue;
                }

                table[newKey] = table[key];
                keys.Add(newKey);
            }
        }
    }
}