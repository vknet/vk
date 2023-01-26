using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Копия изображения обложки.
/// </summary>
[Serializable]
public class GroupCoverImage
{
	/// <summary>
	/// URL копии;
	/// </summary>
	[JsonProperty("url")]
	public Uri Url { get; set; }

	/// <summary>
	/// Ширина копии;
	/// </summary>
	[JsonProperty("width")]
	public int Width { get; set; }

	/// <summary>
	/// Высота копии.
	/// </summary>
	[JsonProperty("height")]
	public int Height { get; set; }
}