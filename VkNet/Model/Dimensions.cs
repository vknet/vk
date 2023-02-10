using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Габариты товара
/// </summary>
[Serializable]
public class Dimensions
{
	/// <summary>
	/// Ширина в миллиметрах
	/// </summary>
	[JsonProperty("width")]
	public int Width { get; set; }

	/// <summary>
	/// Высота в миллиметрах
	/// </summary>
	[JsonProperty("height")]
	public int Height { get; set; }

	/// <summary>
	/// Длина в миллиметрах
	/// </summary>
	[JsonProperty("length")]
	public int Length { get; set; }
}