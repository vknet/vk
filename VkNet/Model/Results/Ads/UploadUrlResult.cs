using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model;

/// <summary>
/// Результат метода Ads.UploadUrl
/// </summary>
[Serializable]
public class UploadUrlResult
{
	/// <summary>
	/// В случае удачной загрузки
	/// </summary>
	[JsonProperty("photo")]
	public string Photo { get; set; }

	/// <summary>
	/// В случае ошибки
	/// </summary>
	[JsonProperty("errcode")]
	public int ErrCode { get; set; }
}