using System;
using Newtonsoft.Json;

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
}