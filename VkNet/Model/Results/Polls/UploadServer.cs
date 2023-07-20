using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Результат метода GetPhotoUploadServer
/// </summary>
[Serializable]
public class UploadServer
{
	/// <summary>
	/// Идентификатор владельца опроса.
	/// </summary>
	[JsonProperty("upload_url")]
	public string UploadUrl { get; set; }
}