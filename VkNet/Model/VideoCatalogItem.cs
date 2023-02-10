using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

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
	[JsonConverter(typeof(SafetyEnumJsonConverter))]
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

	/// <summary>
	/// ��������� �� json.
	/// </summary>
	/// <param name="response"> ����� �������. </param>
	/// <returns> </returns>
	public static VideoCatalogItem FromJson(VkResponse response)
	{
		var item = new VideoCatalogItem
		{
			Id = response[key: "id"],
			OwnerId = response[key: "owner_id"],
			Title = response[key: "title"],
			Type = response[key: "type"],
			Duration = response[key: "duration"],
			Description = response[key: "description"],
			Date = response[key: "date"],
			Views = response[key: "views"],
			Comments = response[key: "comments"],
			Photo130 = response[key: "photo_130"],
			Photo320 = response[key: "photo_320"],
			Photo640 = response[key: "photo_640"],
			CanAdd = response[key: "can_add"],
			CanEdit = response[key: "can_edit"],
			Count = response[key: "count"],
			Photo160 = response[key: "photo_160"],
			UpdatedTime = response[key: "updated_time"],
			IsPrivate = response[key: "is_private"],
			AddingDate = response[key: "adding_date"],
			Photo800 = response[key: "photo_800"]
		};

		return item;
	}
}