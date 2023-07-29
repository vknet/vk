using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Статистика по полу возрасту и городу
/// </summary>
[Serializable]
public class StatsSexAgeCities
{
	/// <summary>
	/// Идентификатор рекламного кабинета. обязательный параметр, целое число
	/// </summary>
	[JsonProperty("impressions_rate")]
	public long ImpressionsRate { get; set; }

	/// <summary>
	/// обязательный параметр, строка
	/// </summary>
	[JsonProperty("clicks_rate")]
	public long ClicksRate { get; set; }

	/// <summary>
	/// обязательный параметр, строка
	/// </summary>
	[JsonProperty("value")]
	public string Value { get; set; }

	/// <summary>
	/// обязательный параметр, строка
	/// </summary>
	[JsonProperty("name")]
	public string Name { get; set; }
}