using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Секция катеогории товара
/// </summary>
[Serializable]
public class MarketCategorySection
{
	/// <summary>
	/// Идентификатор
	/// </summary>
	[JsonProperty("id")]
	public long? Id { get; set; }

	/// <summary>
	/// Название секции
	/// </summary>
	[JsonProperty("name")]
	public string Name { get; set; }
}