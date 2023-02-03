using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Копия изображения обложки.
/// </summary>
[Serializable]
public class AppImageResult
{
	/// <summary>
	/// Общее число результатов
	/// </summary>
	[JsonProperty("count")]
	public int Count { get; set; }

	/// <summary>
	/// Массив объектов, описывающих изображения
	/// </summary>
	[JsonProperty("items")]
	public IEnumerable<AppImage> Items { get; set; }
}