using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Категории для каталога сообществ
/// </summary>
[Serializable]
public class AdsCategories
{
	/// <summary>
	/// Название категории.
	/// </summary>
	[JsonProperty(propertyName: "name")]
	public string Name { get; set; }

	/// <summary>
	/// Gets or sets the subcategories.
	/// </summary>
	[JsonProperty(propertyName: "subcategories")]
	public IEnumerable<AdsCategories> Subcategories { get; set; }

	/// <summary>
	/// Идентификатор.
	/// </summary>
	[JsonProperty(propertyName: "id")]
	public long Id { get; set; }
}