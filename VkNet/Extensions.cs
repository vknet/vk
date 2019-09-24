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
			var created =doc.DocumentNode.Descendants("ya:created").ToArray()[0];
			var dataStr = created.Attributes["dc:date"].Value;
			return  Convert.ToDateTime(dataStr);
		}
	}
}