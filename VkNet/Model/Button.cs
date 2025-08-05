using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Кнопка.
/// </summary>
[Serializable]
public class Button
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
	public Uri Uri { get; set; }

	/// <summary>
	/// Действие
	/// </summary>
	[JsonProperty("action")]
	public LinkButtonAction Action { get; set; }
}