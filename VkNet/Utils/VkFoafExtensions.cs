using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;
using VkNet.Model;
using System.Threading;

namespace VkNet.Utils;

/// <summary>
/// Методы расширения для взаимодействия с https://vk.com/foaf.php
/// </summary>
public static class VkFoafExtensions
{
	/// <summary>
	/// return self registration date
	/// </summary>
	/// <param name="user">Пользователь</param>
	/// <param name="token">Токен отмены операции</param>
	/// <returns>
	/// Дата регистрации
	/// </returns>
	[SuppressMessage("ReSharper", "MethodSupportsCancellation")]
	public static async Task<DateTime> GetRegistrationDateAsync(this User user, CancellationToken token = default)
	{
		using var httpClient = new HttpClient();

		var str = await httpClient.GetStringAsync($"https://vk.com/foaf.php?id={user.Id}")
			.ConfigureAwait(false);

		var doc = new HtmlDocument();
		doc.LoadHtml(str);

		var created = doc.DocumentNode.Descendants("ya:created")
			.FirstOrDefault();

		var dataStr = created?.Attributes["dc:date"]
						?.Value
					?? throw new InvalidOperationException("can't parse meta files");

		return Convert.ToDateTime(dataStr);
	}
}