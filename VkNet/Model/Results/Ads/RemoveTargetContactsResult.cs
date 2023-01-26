using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Результат выполнения метода RemoveTargetContactsResult
/// </summary>
[Serializable]
public class RemoveTargetContactsResult
{
	/// <summary>
	/// Результат.
	/// </summary>
	[JsonProperty("result")]
	public bool Result { get; set; }
}