using System;
using Newtonsoft.Json;

namespace VkNet.Model.Results.Asr;

/// <summary>
/// Объект UploadUrl
/// </summary>
[Serializable]
public class UploadUrlResult
{
	/// <summary>
	/// Ссылка на адрес сервера для загрузки аудиозаписи
	/// </summary>
	[JsonProperty("upload_url")]
	public Uri UploadUrl { get; set; }
}