using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Адрес сервера для загрузки фотографий
/// </summary>
[Serializable]
public class UploadServerInfo
{
	/// <summary>
	/// Адрес для загрузки фотографий
	/// </summary>
	[JsonProperty("upload_url")]
	public string UploadUrl { get; set; }

	/// <summary>
	/// Идентификатор альбома, в который будет загружена фотография
	/// </summary>
	[JsonProperty("album_id")]
	public long? AlbumId { get; set; }

	/// <summary>
	/// Идентификатор пользователя, от чьего имени будет загружено фото
	/// </summary>
	[JsonProperty("user_id")]
	public long? UserId { get; set; }

	[JsonProperty("aid")]
	private long? Aid
	{
		get => AlbumId;
		set => AlbumId = value;
	}

	[JsonProperty("message_id")]
	private long? MessageId
	{
		get => UserId;
		set => UserId = value;
	}

	[JsonProperty("mid")]
	private long? Mid
	{
		get => UserId;
		set => UserId = value;
	}
}