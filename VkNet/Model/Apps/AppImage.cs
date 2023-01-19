using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model;

/// <summary>
///  Массив объектов, описывающих изображения
/// </summary>
[Serializable]
public class AppImage
{
	/// <summary>
	/// Идентификатор изображения
	/// </summary>
	[JsonProperty("id")]
	public string Id { get; set; }

	/// <summary>
	/// Тип изображения.
	/// </summary>
	[JsonConverter(typeof(SafetyEnumJsonConverter))]
	[JsonProperty("type")]
	public AppWidgetImageType Type { get; set; }

	/// <summary>
	/// Массив копий изображения
	/// </summary>
	[JsonProperty("images")]
	public IEnumerable<Image> Images { get; set; }
}