using System;
using System.Linq;
using System.Threading.Tasks;
using Flurl.Http;
using HtmlAgilityPack;
using VkNet.Model;

namespace VkNet
{
	public static class Extensions
	{
		/// <summary>
		///  Return registration date
		/// </summary>
		/// <param name="user"></param>
		/// <param name="id">id of user</param>
		/// <returns></returns>
		public static async Task<DateTime> GetRegistrationDate(this User user, long id)
		{
			var str = await $"https://vk.com/foaf.php?id={id}".GetStringAsync();
			var doc = new HtmlDocument();
			doc.LoadHtml(str);
			var created = doc.DocumentNode.Descendants("ya:created").FirstOrDefault();

			var dataStr = created?.Attributes["dc:date"]?.Value ?? throw new InvalidOperationException("can't parse meta files");

			return Convert.ToDateTime(dataStr);
		}

		/// <summary>
		/// return self registration date
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
		public static async Task<DateTime> GetRegistrationDate(this User user)
		{
			var str = await $"https://vk.com/foaf.php?id={user.Id}".GetStringAsync();
			var doc = new HtmlDocument();
			doc.LoadHtml(str);
			var created = doc.DocumentNode.Descendants("ya:created").FirstOrDefault();

			var dataStr = created?.Attributes["dc:date"]?.Value ?? throw new InvalidOperationException("can't parse meta files");

			return Convert.ToDateTime(dataStr);
		}
	}
}
