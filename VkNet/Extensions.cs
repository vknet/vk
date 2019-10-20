using System;
using System.Linq;
using Flurl.Http;
using HtmlAgilityPack;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet
{
	public static class Extensions
	{
		public static DateTime GetRegistarationDate(this User user,long id)
		{
			var str = $"https://vk.com/foaf.php?id={id}".GetStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();
			var doc = new HtmlDocument() ;
			doc.LoadHtml(str);
			var dataStr = created?.Attributes["dc:date"]?.Value == null
				? created.Attributes["dc:date"].Value
				: throw new InvalidOperationException("can't parse meta files");
			return  Convert.ToDateTime(dataStr);
		}
	}
}
