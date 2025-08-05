using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Ключевые слова
/// </summary>
[Serializable]
public class StickersKeywords
{
	/// <summary>
	/// базовый URL для стикеров
	/// </summary>
	[JsonProperty("base_url")]
	public string BaseUrl { get; set; }

	/// <summary>
	/// Количество объектов
	/// </summary>
	[JsonProperty("count")]
	public int Count { get; set; }

	/// <summary>
	/// Коллекция объектов, описывающих подсказки
	/// </summary>
	[JsonProperty("dictionary")]
	public List<Hint> Dictionary { get; set; }
}