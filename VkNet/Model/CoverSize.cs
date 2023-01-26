using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Размер
/// </summary>
[Serializable]
public class CoverSize
{
	/// <summary>
	/// URL
	/// </summary>
	[JsonProperty("url")]
	public Uri Url { get; set; }

	/// <summary>
	/// Ширина
	/// </summary>
	[JsonProperty("width")]
	public long Width { get; set; }

	/// <summary>
	/// Высота
	/// </summary>
	[JsonProperty("height")]
	public long Height { get; set; }

	/// <summary>
	/// Тип
	/// </summary>
	[JsonProperty("type")]
	public string Type { get; set; }
}