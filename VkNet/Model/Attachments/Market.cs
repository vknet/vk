using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Enums;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model;

/// <summary>
/// Информация о продукте.
/// </summary>
[Serializable]
public class Market : MediaAttachment
{
	/// <inheritdoc />
	protected override string Alias => "market";

	private long? _id;
	/// <summary>
	/// Id
	/// </summary>
	[JsonProperty("id")]
	public new long? Id
	{
		get => _id;

		set { if(value == null) _id ??= -1; }
	}

	/// <summary>
	/// Название товара
	/// </summary>
	[JsonProperty("title")]
	public string Title { get; set; }

	/// <summary>
	/// Текст описания товара
	/// </summary>
	[JsonProperty("description")]
	public string Description { get; set; }

	/// <summary>
	/// Цена
	/// </summary>
	[JsonProperty("price")]
	public Price Price { get; set; }

	/// <summary>
	/// Габариты товара.
	/// </summary>
	[JsonProperty("dimensions")]
	public Dimensions Dimensions { get; set; }

	/// <summary>
	/// Категория товара
	/// </summary>
	[JsonProperty("category")]
	public MarketCategory Category { get; set; }

	/// <summary>
	/// URL изображения-обложки товара
	/// </summary>
	[JsonProperty("thumb_photo")]
	public Uri ThumbPhoto { get; set; }

	/// <summary>
	/// Дата создания товара в формате Unixtime.
	/// </summary>
	[JsonProperty("date")]
	[JsonConverter(typeof(UnixDateTimeConverter))]
	public DateTime? Date { get; set; }

	/// <summary>
	/// Статус доступности товара
	/// </summary>
	[JsonProperty("availability")]
	public ProductAvailability Availability { get; set; }

	/// <summary>
	/// Изображения товара
	/// </summary>
	[JsonProperty("photos")]
	public ReadOnlyCollection<Photo> Photos { get; set; }

	/// <summary>
	/// Возможность комментировать товар для текущего пользователя
	/// </summary>
	[JsonProperty("can_comment")]
	public bool? CanComment { get; set; }

	/// <summary>
	/// Возможность сделать репост товара для текущего пользователя
	/// </summary>
	[JsonProperty("can_repost")]
	public bool? CanRepost { get; set; }

	/// <summary>
	/// Информация об отметках «Мне нравится»
	/// </summary>
	[JsonProperty("likes")]
	public Likes Likes { get; set; }

	/// <summary>
	/// Cсылка на товар во внешних ресурсах.
	/// </summary>
	[JsonProperty("url")]
	public Uri Url { get; set; }

	/// <summary>
	/// Текст на кнопке товара.
	/// </summary>
	[JsonProperty("button_title")]
	[JsonConverter(typeof(SafetyEnumJsonConverter))]
	public MarketItemButtonTitle ButtonTitle { get; set; }
}