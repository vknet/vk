using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Информация об ответах на текущую историю.
/// </summary>
[Serializable]
public class StoryReplies
{
	/// <summary>
	/// Число ответов
	/// </summary>
	[JsonProperty("count")]
	public int Count { get; set; }

	/// <summary>
	/// Число новых ответов.
	/// </summary>
	[JsonProperty("new")]
	public int? New { get; set; }
}