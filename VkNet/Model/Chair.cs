using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model;

/// <summary>
/// Кафедра
/// </summary>
[Serializable]
public class Chair
{
	/// <summary>
	/// Идентификатор факультета
	/// </summary>
	[JsonProperty("id")]
	public long Id { get; set; }

	/// <summary>
	/// Название факультета
	/// </summary>
	[JsonProperty("title")]
	public string Title { get; set; }
}