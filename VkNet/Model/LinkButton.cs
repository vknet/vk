using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model;

/// <summary>
/// ССылочная кнопка
/// </summary>
[Serializable]
public class LinkButton
{
	/// <summary>
	/// Название кнопки.
	/// </summary>
	[JsonProperty("title")]
	public string Title { get; set; }

	/// <summary>
	/// Ссылка на которую ведет кнопка.
	/// </summary>
	[JsonProperty("url")]
	public LinkButtonAction Uri { get; set; }

	/// <summary>
	/// Разобрать из json.
	/// </summary>
	/// <param name="response"> Ответ сервера. </param>
	/// <returns> </returns>
	public static LinkButton FromJson(VkResponse response) => new()
	{
		Title = response[key: "title"],
		Uri = response[key: "url"]
	};
}