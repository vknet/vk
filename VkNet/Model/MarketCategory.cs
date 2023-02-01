using System;
using Newtonsoft.Json;
using VkNet.Utils;

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

	/// <summary>
	/// Разобрать из json.
	/// </summary>
	/// <param name="response"> Ответ сервера. </param>
	/// <returns> </returns>
	public static MarketCategory FromJson(VkResponse response)
	{
		var product = new MarketCategory
		{
			Id = response[key: "id"],
			Name = response[key: "name"],
			Section = response[key: "section"]
		};

		return product;
	}
}