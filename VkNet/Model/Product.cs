using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Enums.StringEnums;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model;

/// <summary>
/// Продукт
/// </summary>
[Serializable]
public class Product
{
	/// <summary>
	/// Идентификатор продукта
	/// </summary>
	[JsonProperty("id")]
	public long Id { get; set; }

	/// <summary>
	/// Тип продукта
	/// </summary>
	[JsonProperty("type")]
	[JsonConverter(typeof(TolerantStringEnumConverter))]
	public ProductType Type { get; set; }

	/// <summary>
	/// Является ли продукт новым
	/// </summary>
	[JsonProperty("is_new")]
	public bool IsNew { get; set; }

	/// <summary>
	/// Копирайт
	/// </summary>
	[JsonProperty("copyright")]
	public string Copyright { get; set; }

	/// <summary>
	/// Куплен ли продукт
	/// </summary>
	[JsonProperty("purchased")]
	public bool Purchased { get; set; }

	/// <summary>
	/// Активен ли продукт
	/// </summary>
	[JsonProperty("active")]
	public bool Active { get; set; }

	/// <summary>
	/// Является ли продукт рекламным
	/// </summary>
	[JsonProperty("promoted ")]
	public bool Promoted { get; set; }

	/// <summary>
	/// Дата покупки
	/// </summary>
	[JsonProperty("purchase_date")]
	[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
	public DateTime? PurchaseDate { get; set; }

	/// <summary>
	/// Название продукта
	/// </summary>
	[JsonProperty("title")]
	public string Title { get; set; }

	/// <summary>
	/// Стикеры
	/// </summary>
	[JsonProperty("stickers")]
	public List<Sticker> Stickers { get; set; }

	/// <summary>
	/// Иконка продукта
	/// </summary>
	[JsonProperty("icon")]
	public Icon Icon { get; set; }

	/// <summary>
	/// Превью
	/// </summary>
	[JsonProperty("previews")]
	public List<Image> Previews { get; set; }
}