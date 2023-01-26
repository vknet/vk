using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Факультет
/// </summary>
[Serializable]
public class Faculty
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