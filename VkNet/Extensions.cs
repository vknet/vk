using System;
using System.Linq;
using System.Threading.Tasks;
using Flurl.Http;
using HtmlAgilityPack;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet
{
	public static class Extensions
	{
		public static async Task<DateTime> GetRegistarationDate(this User user,long id)
		{
			var str = await $"https://vk.com/foaf.php?id={id}".GetStringAsync();
			var doc = new HtmlDocument() ;
			doc.LoadHtml(str);
			var dataStr = created?.Attributes["dc:date"]?.Value == null
				? created.Attributes["dc:date"].Value
				: throw new InvalidOperationException("can't parse meta files");
			return  Convert.ToDateTime(dataStr);
		}
	}
}
