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
		/// Cookies.
		/// </summary>
		public Cookies()
		{
			Container = new CookieContainer();
		}

		/// <summary>
		/// Получить контейнер Cookies.
		/// </summary>
		public CookieContainer Container { get; }

		/// <summary>
		/// Добавить из.
		/// </summary>
		/// <param name="responseUrl"> URL ответа. </param>
		/// <param name="cookies"> Cookies. </param>
		public void AddFrom(Uri responseUrl, CookieCollection cookies)
		{
			foreach (Cookie cookie in cookies)
			{
				Container.Add(uri: responseUrl, cookie: cookie);
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
					.InvokeMember(name: "m_domainTable"
							, invokeAttr: BindingFlags.NonPublic|BindingFlags.GetField|BindingFlags.Instance
							, binder: null
							, target: Container
							, args: new object[] {});
		#else
					.GetRuntimeFields()
					.FirstOrDefault(predicate: x => x.Name == "m_domainTable" || x.Name == "_domainTable")
					?.GetValue(obj: Container);
		#endif

			if (table == null)
			{
				return;
			}

			var keys = table.Keys.OfType<string>().ToList();

			foreach (var key in table.Keys.OfType<string>().ToList())
			{
				if (key[index: 0] != '.')
				{
					continue;
				}

				var newKey = key.Remove(startIndex: 0, count: 1);

				if (keys.Contains(item: newKey))
				{
					continue;
				}

				table[key: newKey] = table[key: key];
				keys.Add(item: newKey);
			}
		}
	}
}