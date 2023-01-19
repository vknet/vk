using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model;

/// <summary>
/// Результат метода GetPhotoUploadServer
/// </summary>
[Serializable]
public class PhotoUploadServer
{
	/// <summary>
	/// Идентификатор владельца опроса.
	/// </summary>
	[JsonProperty("upload_url")]
	public string UploadUrl { get; set; }
}