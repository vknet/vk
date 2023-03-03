using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Категория товара.
/// </summary>
[Serializable]
public class MarketCategory
{
	/// <summary>
	/// Идентификатор
	/// </summary>
	[JsonProperty("id")]
	public long? Id { get; set; }

	/// <summary>
	/// Название категории
	/// </summary>
	[JsonProperty("name")]
	public string Name { get; set; }

	/// <summary>
	/// Секция
	/// </summary>
	[JsonProperty("section")]
	public MarketCategorySection Section { get; set; }
}