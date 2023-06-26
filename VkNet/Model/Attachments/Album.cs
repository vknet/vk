using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace VkNet.Model;

/// <summary>
/// Альбом с фотографиями пользователя.
/// См. описание http://vk.com/dev/attachments_w
/// </summary>
[Serializable]
public class Album : MediaAttachment
{
	/// <inheritdoc />
	protected override string Alias => "album";

	/// <summary>
	/// Обложка альбома.
	/// </summary>
	[JsonProperty("thumb")]
	public Photo Thumb { get; set; }

	/// <summary>
	/// Название альбома.
	/// </summary>
	[JsonProperty("title")]
	public string Title { get; set; }

	/// <summary>
	/// Описание альбома.
	/// </summary>
	[JsonProperty("description")]
	public string Description { get; set; }

	/// <summary>
	/// Дата и время создания альбома.
	/// </summary>
	[JsonProperty("created")]
	[JsonConverter(typeof(UnixDateTimeConverter))]
	public DateTime? CreateTime { get; set; }

	/// <summary>
	/// Дата и время последнего обновления альбома.
	/// </summary>
	[JsonProperty("updated")]
	[JsonConverter(typeof(UnixDateTimeConverter))]
	public DateTime? UpdateTime { get; set; }

	/// <summary>
	/// Количество фотографий в альбоме.
	/// </summary>
	[JsonProperty("size")]
	public int Size { get; set; }

	[JsonProperty("aid")]
	private long? Aid
	{
		get => Id;
		set => Id = value;
	}

	[JsonProperty("album_id")]
	private long? AlbumId
	{
		get => Id;
		set => Id = value;
	}
}