using System;
using System.Collections.Generic;
using VkNet.Utils;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Категории для каталога сообществ
/// </summary>
[Serializable]
public class CategoryGroup
{
	/// <summary>
	/// Название категории.
	/// </summary>
	[JsonProperty("name")]
	public string Name { get; set; }

	/// <summary>
	/// Gets or sets the subcategories.
	/// </summary>
	[JsonProperty("subcategories")]
	public IEnumerable<CategoryGroup> Subcategories { get; set; }

	/// <summary>
	/// Количество сообществ в категории.
	/// </summary>
	[JsonProperty("page_count")]
	public long? PageCount { get; set; }

	/// <summary>
	/// Массив объектов сообществ для предпросмотра.
	/// </summary>
	[JsonProperty("page_previews")]
	public IEnumerable<Group> PagePreviews { get; set; }

	/// <summary>
	/// Идентификатор.
	/// </summary>
	[JsonProperty("id")]
	public long Id { get; set; }

	/// <summary>
	/// Разобрать из json.
	/// </summary>
	/// <param name="response"> Ответ сервера. </param>
	/// <returns> </returns>
	public static CategoryGroup FromJson(VkResponse response) => new()
	{
		Id = response[key: "id"],
		Name = response[key: "name"],
		Subcategories = response[key: "subcategories"]
			.ToReadOnlyCollectionOf<CategoryGroup>(selector: o => o),
		PageCount = response[key: "page_count"],
		PagePreviews = response[key: "page_previews"]
			.ToReadOnlyCollectionOf<Group>(selector: o => o)
	};
}