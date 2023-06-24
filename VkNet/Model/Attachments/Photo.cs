using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Model.GroupUpdate;

namespace VkNet.Model.Attachments;

/// <summary>
/// Фотография.
/// </summary>
/// <remarks>
/// См. описание http://vk.com/dev/photo
/// </remarks>
[Serializable]
public class Photo : MediaAttachment, IGroupUpdate
{
	/// <inheritdoc />
	protected override string Alias => "photo";

	/// <summary>
	/// Идентификатор альбома, в котором находится фотография.
	/// </summary>
	[JsonProperty("album_id")]
	public long? AlbumId { get; set; }

	/// <summary>
	/// Идентификатор пользователя, загрузившего фото (если фотография размещена в
	/// сообществе). Для фотографий, размещенных
	/// от имени сообщества.
	/// </summary>
	[JsonProperty("user_id")]
	public long? UserId { get; set; }

	/// <summary>
	/// Текст описания фотографии.
	/// </summary>
	[JsonProperty("text")]
	public string Text { get; set; }

	/// <summary>
	/// Дата добавления фотографии.
	/// </summary>
	[JsonProperty("date")]
	[JsonConverter(typeof(UnixDateTimeConverter))]
	public DateTime? CreateTime { get; set; }

	/// <summary>
	/// Размеры фотографий.
	/// </summary>
	[JsonProperty("sizes")]
	public ReadOnlyCollection<PhotoSize> Sizes { get; set; }

	/// <summary>
	/// <c>Uri</c> фотографии с максимальным размером 50x50px.
	/// </summary>
	[JsonProperty("photo_50")]
	public Uri Photo50 { get; set; }

	/// <summary>
	/// <c>Uri</c> фотографии с максимальным размером 75x75px.
	/// </summary>
	[JsonProperty("photo_75")]
	public Uri Photo75 { get; set; }

	/// <summary>
	/// <c>Uri</c> фотографии с максимальным размером 100x100px.
	/// </summary>
	[JsonProperty("photo_100")]
	public Uri Photo100 { get; set; }

	/// <summary>
	/// <c>Uri></c> фотографии с максимальным размером 130x130px.
	/// </summary>
	[JsonProperty("photo_130")]
	public Uri Photo130 { get; set; }

	/// <summary>
	/// <c>Uri</c> фотографии с максимальным размером 200x200px.
	/// </summary>
	[JsonProperty("photo_200")]
	public Uri Photo200 { get; set; }

	/// <summary>
	/// <c>Uri</c> фотографии с максимальным размером 604x604px.
	/// </summary>
	[JsonProperty("photo_604")]
	public Uri Photo604 { get; set; }

	/// <summary>
	/// <c>Uri</c> фотографии с максимальным размером 807x807px.
	/// </summary>
	[JsonProperty("photo_807")]
	public Uri Photo807 { get; set; }

	/// <summary>
	/// <c>Uri</c> фотографии с максимальным размером 1280x1024px.
	/// </summary>
	[JsonProperty("photo_1280")]
	public Uri Photo1280 { get; set; }

	/// <summary>
	/// <c>Uri</c> фотографии с максимальным размером  2560x2048px.
	/// </summary>
	[JsonProperty("photo_2560")]
	public Uri Photo2560 { get; set; }

	/// <summary>
	/// Ширина оригинала фотографии в пикселах
	/// </summary>
	[JsonProperty("width")]
	public int? Width { get; set; }

	/// <summary>
	/// Высота оригинала фотографии в пикселах.
	/// </summary>
	[JsonProperty("height")]
	public int? Height { get; set; }

	/// <summary>
	/// Url фотографии.
	/// </summary>
	[JsonProperty("url")]
	public Uri Url { get; set; }

	[JsonProperty("pid")]
	private long? Pid
	{
		get => Id;
		set => Id = value;
	}

	[JsonProperty("photo_id")]
	private long? PhotoId
	{
		get => Id;
		set => Id = value;
	}

	[JsonProperty("aid")]
	private long? Aid
	{
		get => AlbumId;
		set => AlbumId = value;
	}

	[JsonProperty("src")]
	private Uri Src
	{
		get => Photo130;
		set => Photo130 = value;
	}

	[JsonProperty("src_big")]
	private Uri SrcBig
	{
		get => Photo604;
		set => Photo604 = value;
	}

	[JsonProperty("src_xbig")]
	private Uri SrcXbig
	{
		get => Photo807;
		set => Photo807 = value;
	}

	[JsonProperty("src_xxbig")]
	private Uri SrcXXbig
	{
		get => Photo1280;
		set => Photo1280 = value;
	}

	[JsonProperty("src_xxxbig")]
	private Uri SrcXXXbig
	{
		get => Photo2560;
		set => Photo2560 = value;
	}

	[JsonProperty("created")]
	private DateTime? Created
	{
		get => CreateTime;
		set => CreateTime = value;
	}

	#region опциональные поля

	/// <summary>
	/// Идентификатор записи, у которой данная фотография является прикреплением???
	/// </summary>
	[JsonProperty("post_id")]
	public long? PostId { get; set; }

	/// <summary>
	/// Идентификатор пользователя, сделавшего отметку
	/// </summary>
	[JsonProperty("placer_id")]
	public long? PlacerId { get; set; }

	/// <summary>
	/// Дата создания отметки
	/// </summary>
	[JsonProperty("tag_created")]
	[JsonConverter(typeof(UnixDateTimeConverter))]
	public DateTime? TagCreated { get; set; }

	/// <summary>
	/// Идентификатор отметки
	/// </summary>
	[JsonProperty("tag_id")]
	public long? TagId { get; set; }

	/// <summary>
	/// Лайки
	/// </summary>
	[JsonProperty("likes")]
	public Likes Likes { get; set; }

	/// <summary>
	/// Возможность комментирования фотографии
	/// </summary>
	[JsonProperty("can_comment")]
	public bool? CanComment { get; set; }

	/// <summary>
	/// Комментарии
	/// </summary>
	[JsonProperty("comments")]
	public Comments Comments { get; set; }

	/// <summary>
	/// Репосты
	/// </summary>
	[JsonProperty("reposts")]
	public Reposts Reposts { get; set; }

	/// <summary>
	/// Теги
	/// </summary>
	[JsonProperty("tags")]
	public Tags Tags { get; set; }

	/// <summary>
	/// Существование тегов
	/// </summary>
	[JsonProperty("has_tags")]
	public bool HasTags { get; set; }

	/// <summary>
	/// Источник изображения.
	/// </summary>
	[JsonProperty("photo_src")]
	public Uri PhotoSrc { get; set; }

	/// <summary>
	/// Хеш изображения.
	/// </summary>
	[JsonProperty("photo_hash")]
	public string PhotoHash { get; set; }

	/// <summary>
	/// Географическая широта отметки, заданная в градусах
	/// </summary>
	[JsonProperty("lat")]
	public double? Latitude { get; set; }

	/// <summary>
	/// Географическая долгота отметки, заданная в градусах
	/// </summary>
	[JsonProperty("long")]
	public double? Longitude { get; set; }

	/// <summary>
	/// <c>Uri</c> фотографии с максимальным размером.
	/// </summary>
	[JsonProperty("big_photo_src")]
	public Uri BigPhotoSrc { get; set; }

	/// <summary>
	/// <c>Uri</c> фотографии с минимальным размером.
	/// </summary>
	[JsonProperty("src_small")]
	public Uri SmallPhotoSrc { get; set; }

	#endregion
}