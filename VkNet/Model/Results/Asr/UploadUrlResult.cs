using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Объект UploadUrl
/// </summary>
[Serializable]
public class AsrUploadUrlResult
{
	/// <summary>
	/// Ссылка на адрес сервера для загрузки аудиозаписи
	/// </summary>
	[JsonProperty("upload_url")]
	public Uri UploadUrl { get; set; }
}