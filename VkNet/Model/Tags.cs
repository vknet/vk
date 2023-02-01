using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Теги.
/// </summary>
[Serializable]
public class Tags
{
	/// <summary>
	/// Количество.
	/// </summary>
	[JsonProperty("count")]
	public int Count { get; set; }
}