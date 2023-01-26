using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Количество
/// </summary>
[Serializable]
public class AmountObject
{
	/// <summary>
	/// Количество
	/// </summary>
	[JsonProperty("amount")]
	public long Amount { get; set; }

	/// <summary>
	/// Валюта
	/// </summary>
	[JsonProperty("currency")]
	public Currency Currency { get; set; }

	/// <summary>
	/// Текст
	/// </summary>
	[JsonProperty("text")]
	public string Text { get; set; }
}