using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using VkNet.Enums.StringEnums;

namespace VkNet.Model;

/// <summary>
/// Фон сниппета опроса.
/// </summary>
[Serializable]
public class PollBackground
{
	/// <summary>
	/// Идентификатор фона.
	/// </summary>
	[JsonProperty("id")]
	public long? Id { get; set; }

	/// <summary>
	/// Тип фона.
	/// </summary>
	[JsonProperty("type")]
	public PollBackgroundType Type { get; set; }

	/// <summary>
	/// (для type = gradient) угол градиента по оси X.
	/// </summary>
	[JsonProperty("angle")]
	public int? Angle { get; set; }

	/// <summary>
	/// HEX-код замещающего цвета (без #).
	/// </summary>
	[JsonProperty("color")]
	public string Color { get; set; }

	/// <summary>
	/// (для type = tile) ширина плитки паттерна.
	/// </summary>
	[JsonProperty("width")]
	public int? Width { get; set; }

	/// <summary>
	/// (для type = tile) высота плитки паттерна.
	/// </summary>
	[JsonProperty("height")]
	public int? Height { get; set; }

	/// <summary>
	/// (для type = tile) изображение плитки паттерна. Массив объектов изображений.
	/// </summary>
	[JsonProperty("images")]
	public ReadOnlyCollection<Photo> Images { get; set; }

	/// <summary>
	/// (для type = gradient) точки градиента.
	/// </summary>
	[JsonProperty("points")]
	public ReadOnlyCollection<PollBackgroundPoint> Points { get; set; }
}