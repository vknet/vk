using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;
using VkNet.Model;

namespace VkNet.Utils
{
	/// <summary>
	/// Методы расширения для взаимодействия с https://vk.com/foaf.php
	/// </summary>
	public static class VkFoafExtensions
	{
		/// <summary>
		/// return self registration date
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
		public static async Task<DateTime> GetRegistrationDateAsync(this User user)
		{
			using (var httpClient = new HttpClient())
			{
				var str = await httpClient.GetStringAsync($"https://vk.com/foaf.php?id={user.Id}").ConfigureAwait(false);
				var doc = new HtmlDocument();
				doc.LoadHtml(str);
				var created = doc.DocumentNode.Descendants("ya:created").FirstOrDefault();

				var dataStr = created?.Attributes["dc:date"]?.Value ?? throw new InvalidOperationException("can't parse meta files");

				return Convert.ToDateTime(dataStr);
			}
		}
	}
}