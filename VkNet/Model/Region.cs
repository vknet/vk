using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Регион
/// </summary>
[Serializable]
public class Region
{
	/// <summary>
	/// Идентификатор региона
	/// </summary>
	[JsonProperty("id")]
	public int Id { get; set; }

	/// <summary>
	/// Название региона
	/// </summary>
	[JsonProperty("title")]
	public string Title { get; set; }
}