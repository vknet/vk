using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Enums.StringEnums;

namespace VkNet.Model;

/// <summary>
/// Объект, описывающий элемент видеокаталога
/// </summary>
[Serializable]
public class VideoCatalogItem
{
	/// <summary>
	/// идентификатор элемента.
	/// </summary>
	[JsonProperty("id")]
	public long Id { get; set; }

	/// <summary>
	/// идентификатор владельца элемента.
	/// </summary>
	[JsonProperty("owner_id")]
	public long OwnerId { get; set; }

	/// <summary>
	/// название элемента.
	/// </summary>
	[JsonProperty("title")]
	public string Title { get; set; }

	/// <summary>
	/// тип элемента.
	/// </summary>
	[JsonProperty("type")]
	public VideoCatalogItemType Type { get; set; }

	/// <summary>
	/// текст описания.
	/// </summary>
	[JsonProperty("description")]
	public string Description { get; set; }

	/// <summary>
	/// длительность ролика в секундах.
	/// </summary>
	[JsonProperty("duration")]
	public long? Duration { get; set; }

	/// <summary>
	/// URL изображения-обложки ролика шириной 130px.
	/// </summary>
	[JsonProperty("photo_130")]
	public Uri Photo130 { get; set; }

	/// <summary>
	/// URL изображения-обложки ролика шириной 320px.
	/// </summary>
	[JsonProperty("photo_320")]
	public Uri Photo320 { get; set; }

	/// <summary>
	/// URL изображения-обложки ролика шириной 640px (если размер есть).
	/// </summary>
	[JsonProperty("photo_640")]
	public Uri Photo640 { get; set; }

	/// <summary>
	/// URL изображения-обложки ролика шириной 800px (если размер есть).
	/// </summary>
	[JsonProperty(propertyName: "photo_800")]
	public Uri Photo800 { get; set; }

	/// <summary>
	/// дата создания видеозаписи в формате Unixtime.
	/// </summary>
	[JsonProperty("date")]
	[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
	public DateTime? Date { get; set; }

	/// <summary>
	/// дата добавления видеозаписи пользователем или группой в формате Unixtime.
	/// </summary>
	[JsonProperty(propertyName: "adding_date")]
	[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
	public DateTime? AddingDate { get; set; }

	/// <summary>
	/// количество просмотров видеозаписи.
	/// </summary>
	[JsonProperty("views")]
	public long? Views { get; set; }

	/// <summary>
	/// количество комментариев к видеозаписи.
	/// </summary>
	[JsonProperty("comments")]
	public long? Comments { get; set; }

	/// <summary>
	/// наличие возможности добавить ролик в свой список.
	/// </summary>
	[JsonProperty("can_add")]
	public bool? CanAdd { get; set; }

	/// <summary>
	/// наличие возможности редактировать видео.
	/// </summary>
	[JsonProperty("can_edit")]
	public bool? CanEdit { get; set; }

	/// <summary>
	/// приватность ролика (0 — нет, 1 — есть).
	/// </summary>
	[JsonProperty(propertyName: "is_private")]
	public bool? IsPrivate { get; set; }

	/// <summary>
	/// число видеозаписей в альбоме.
	/// </summary>
	[JsonProperty("count")]
	public long? Count { get; set; }

	/// <summary>
	/// URL изображения-обложки альбома с размером 272x150px.
	/// </summary>
	[JsonProperty("photo_160")]
	public Uri Photo160 { get; set; }

	/// <summary>
	/// время последнего обновления альбома в формате unixtime.
	/// </summary>
	[JsonProperty("updated_time")]
	[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
	public DateTime? UpdatedTime { get; set; }
}