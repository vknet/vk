using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Данные для загрузки фотографии/видео в историю.
/// </summary>
[Serializable]
public class StoryServerUrl
{
	/// <summary>
	/// Адрес сервера для загрузки файла.
	/// </summary>
	[JsonProperty("upload_url")]
	public Uri UploadUrl { get; set; }

	/// <summary>
	/// Идентификаторы пользователей, которые могут видеть историю.
	/// </summary>
	[Obsolete("Начиная с версии 5.118 используется только параметр uploadResults")]
	[JsonProperty("user_ids")]
	public IEnumerable<long> UsersIds { get; set; }

	/// <summary>
	/// Идентификаторы получателей, которые могут видеть историю.
	/// </summary>
	[Obsolete("Начиная с версии 5.118 используется только параметр uploadResults")]
	[JsonProperty("peer_ids")]
	public IEnumerable<long> PeerIds { get; set; }
}