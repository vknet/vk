using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Информация о просмотрах записи.
/// </summary>
[Serializable]
public class PostView
{
	/// <summary>
	/// Число просмотров записи.
	/// </summary>
	[JsonProperty("count")]
	public int Count { get; set; }
}