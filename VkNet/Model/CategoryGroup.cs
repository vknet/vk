using System;
using System.Collections.Generic;
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
}