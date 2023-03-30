using System;
using Newtonsoft.Json;
using VkNet.Enums.SafetyEnums;

namespace VkNet.Model;

/// <summary>
/// Формат описания размеров фотографи.
/// </summary>
[Serializable]
public class PhotoSize
{
	/// <summary>
	/// Uri копии изображения.
	/// </summary>
	[JsonProperty("src")]
	public Uri Src { get; set; }

	/// <summary>
	/// Uri копии изображения.
	/// </summary>
	[JsonProperty("url")]
	public Uri Url { get; set; }

	/// <summary>
	/// Ширина копии в пикселах.
	/// </summary>
	[JsonProperty("width")]
	public ulong Width { get; set; }

	/// <summary>
	/// Высота копии в пикселах.
	/// </summary>
	[JsonProperty("height")]
	public ulong Height { get; set; }

	/// <summary>
	/// Обозначение размера и пропорций копии.
	/// </summary>
	[JsonProperty("type")]
	public PhotoSizeType Type { get; set; }
}