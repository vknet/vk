using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace VkNet.Model;

/// <summary>
/// Альбом для фотографий
/// </summary>
[Serializable]
public class PhotoAlbum
{
	/// <summary>
	/// Идентификатор созданного альбома
	/// </summary>
	[JsonProperty("id")]
	public long Id { get; set; }

	/// <summary>
	/// Идентификатор фотографии, которая является обложкой альбома
	/// </summary>
	[JsonProperty("thumb_id")]
	public long? ThumbId { get; set; }

	/// <summary>
	/// Идентификатор пользователя или сообщества, которому принадлежит альбом
	/// </summary>
	[JsonProperty("owner_id")]
	public long? OwnerId { get; set; }

	/// <summary>
	/// Название альбома
	/// </summary>
	[JsonProperty("title")]
	public string Title { get; set; }

	/// <summary>
	/// Описание альбома
	/// </summary>
	[JsonProperty("description")]
	public string Description { get; set; }

	/// <summary>
	/// Дата создания альбома
	/// </summary>
	[JsonProperty("created")]
	[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
	public DateTime? Created { get; set; }

	/// <summary>
	/// Дата обновления альбома
	/// </summary>
	[JsonProperty("updated")]
	[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
	public DateTime? Updated { get; set; }

	/// <summary>
	/// Количество фотографий в альбоме
	/// </summary>
	[JsonProperty("size")]
	public int? Size { get; set; }

	/// <summary>
	/// Настройки приватности для альбома в формате настроек приватности; (не приходит
	/// для системных альбомов)
	/// </summary>
	[JsonProperty("privacy_view")]
	public PrivacySettingsValue PrivacyView { get; set; }

	/// <summary>
	/// Настройки приватности для комментирования альбома
	/// </summary>
	[JsonProperty("privacy_comment")]
	public PrivacySettingsValue PrivacyComment { get; set; }

	/// <summary>
	/// Может ли текущий пользователь добавлять фотографии в альбом
	/// </summary>
	[JsonProperty("can_upload")]
	public bool? CanUpload { get; set; }

	/// <summary>
	/// Адрес на изображение с предпросмотром
	/// </summary>
	[JsonProperty("thumb_src")]
	public string ThumbSrc { get; set; }

	/// <summary>
	/// Размеры фотографий.
	/// </summary>
	[JsonProperty("sizes")]
	public IEnumerable<PhotoSize> Sizes { get; set; }

	/// <summary>
	/// Комментирование запрещено.
	/// </summary>
	[JsonProperty("comments_disabled")]
	public bool? CommentsDisabled { get; set; }

	/// <summary>
	/// Загружать могут только администраторы.
	/// </summary>
	[JsonProperty("upload_by_admins_only")]
	public bool UploadByAdminsOnly { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether this PhotoAlbum
	/// </summary>
	/// <remarks>
	/// Получено экспериментально.
	/// </remarks>
	[JsonProperty("thumb_is_last")]
	public bool ThumbIsLast { get; set; }

	[JsonProperty("album_id")]
	private long AlbumId
	{
		get => Id;
		set => Id = value;
	}

	[JsonProperty("aid")]
	private long Aid
	{
		get => Id;
		set => Id = value;
	}
}