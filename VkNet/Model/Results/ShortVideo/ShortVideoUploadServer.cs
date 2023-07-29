using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Результат метода ShortVideo.Create
/// </summary>
[Serializable]
public class ShortVideoUploadServer
{
	/// <summary>
	/// Адрес для загрузки Клипа
	/// </summary>
	[JsonProperty("upload_url")]
	public Uri UploadUrl { get; set; }

	/// <summary>
	/// Идентификатор владельца Клипа
	/// </summary>
	[JsonProperty("owner_id")]
	public long? OwnerId { get; set; }

	/// <summary>
	/// Идентификатор Клипа
	/// </summary>
	[JsonProperty("video_id")]
	public long? VideoId { get; set; }
}