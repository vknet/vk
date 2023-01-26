using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Структура статистики
/// </summary>
[Serializable]
public class StatsStruct
{
	/// <summary>
	/// Аудитория для показателя value;.
	/// </summary>
	[JsonProperty("visitors")]
	public long Visitors { get; set; }

	/// <summary>
	/// Значение демографического показателя, имеет разные возможные значения для
	/// разных показателей.
	/// </summary>
	[JsonProperty("value")]
	public string Value { get; set; }

	/// <summary>
	/// Код страны.
	/// </summary>
	[JsonProperty("code")]
	public string Code { get; set; }

	/// <summary>
	/// Наглядное название значения указанного в value (только для городов).
	/// </summary>
	[JsonProperty("name")]
	public string Name { get; set; }
}