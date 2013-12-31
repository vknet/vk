namespace VkToolkit.Utils
{
    using System;
    using System.Collections;
    using System.Linq;
    using System.Net;
    using System.Reflection;

    internal class Cookies
    {
        public CookieContainer Container { get; private set; }

        public Cookies()
        {
            Container = new CookieContainer();
        }

        public void AddFrom(Uri responseUrl, CookieCollection cookies)
        {
            foreach (Cookie cookie in cookies)
                Container.Add(responseUrl, cookie);

            BugFixCookieDomain();
        }

        private void BugFixCookieDomain()
        {
            var table =
                (Hashtable)
                    Container.GetType()
                        .InvokeMember("m_domainTable", BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Instance, null, Container, new object[] { });

            foreach (var key in table.Keys.OfType<string>().ToList())
            {
                if (key[0] == '.')
                {
                    string newKey = key.Remove(0, 1);
                    if (!table.ContainsKey(newKey))
                        table[newKey] = table[key];
                }
            }
        }
    }
}