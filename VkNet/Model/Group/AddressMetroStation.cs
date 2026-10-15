using System;
using System.Diagnostics;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Метро адреса.
/// </summary>
[DebuggerDisplay(value: "[{Id}] ({Name})")]
[Serializable]
public class AddressMetroStation
{
	/// <summary>
	/// Идентификатор станции метро.
	/// </summary>
	[JsonProperty(propertyName: "id")]
	public long? Id { get; set; }

	/// <summary>
	/// Название станции метро.
	/// </summary>
	[JsonProperty(propertyName: "name")]
	public string Name { get; set; }

	/// <summary>
	/// Идентификатор города, к которому относится метро.
	/// </summary>
	[JsonProperty(propertyName: "city_id")]
	public long? CityId { get; set; }

	/// <summary>
	/// Цветовой код линии метро (HEX).
	/// </summary>
	[JsonProperty(propertyName: "color")]
	public string Color { get; set; }
}
