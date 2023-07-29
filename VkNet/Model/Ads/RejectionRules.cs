using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Правила отказа
/// </summary>
[Serializable]
public class RejectionRules
{
	/// <summary>
	/// Заголовок
	/// </summary>
	[JsonProperty("title")]
	public string Title { get; set; }

	/// <summary>
	/// Параграфы
	/// </summary>
	[JsonProperty("paragraphs")]
	public string Paragraphs { get; set; }
}