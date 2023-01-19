using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model;

/// <summary>
/// Результат метода Ads.VideoUploadUrl
/// </summary>
[Serializable]
public class VideoUploadUrlResult
{
	/// <summary>
	/// В случае удачной загрузки
	/// </summary>
	[JsonProperty("video")]
	public string Video { get; set; }

	/// <summary>
	/// В случае ошибки
	/// </summary>
	[JsonProperty("errcode")]
	public int ErrCode { get; set; }
}