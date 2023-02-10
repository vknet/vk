using System;
using Newtonsoft.Json;
using VkNet.Utils;

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

	/// <summary>
	/// Разобрать из json.
	/// </summary>
	/// <param name="response"> Ответ сервера. </param>
	/// <returns> </returns>
	public static MarketCategorySection FromJson(VkResponse response)
	{
		var product = new MarketCategorySection
		{
			Id = response[key: "id"],
			Name = response[key: "name"]
		};

		return product;
	}
}