using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Результат метода SavePhoto
/// </summary>
[Serializable]
public class SavePhotoResult
{
	/// <summary>
	/// Цвет фотографии
	/// </summary>
	[JsonProperty("color")]
	public string Color { get; set; }

	/// <summary>
	/// Идентификатор загруженной фотографии
	/// </summary>
	[JsonProperty("id")]
	public long Id { get; set; }

	/// <summary>
	/// Массив изображений разных размеров
	/// </summary>
	[JsonProperty("images")]
	public Image[] Images { get; set; }
}