using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Результат метода Ads.CreateTargetGroup
/// </summary>
[Serializable]
public class CreateTargetGroupResult
{
	/// <summary>
	/// Идентификатор аудитории.
	/// </summary>
	[JsonProperty("id")]
	public long Id { get; set; }
}