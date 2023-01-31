using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Результат метода ShareTargetGroup
/// </summary>
[Serializable]
public class ShareTargetGroupResult
{
	/// <summary>
	/// Идентификатор аудитории.
	/// </summary>
	[JsonProperty("id")]
	public long Id { get; set; }
}