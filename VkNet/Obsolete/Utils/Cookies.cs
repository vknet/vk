using System;
using System.Collections;
using System.Linq;
using System.Net;
using System.Reflection;

// ReSharper disable once CheckNamespace
namespace VkNet.Utils
{
	/// <summary>
	/// Cookies
	/// </summary>
	[Obsolete(ObsoleteText.ObsoleteClass)]
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
				Container.Add(responseUrl, cookie);
			}

			BugFixCookieDomain();
		}

		/// <summary>
		/// Исправление ошибки в домене указанной куки.
		/// </summary>
		private void BugFixCookieDomain()
		{
			var table = Container.GetType()
				.GetRuntimeFields()
				.FirstOrDefault(x => x.Name == "m_domainTable" || x.Name == "_domainTable")
				?.GetValue(Container) as IDictionary;

			if (table == null)
			{
				return;
			}

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