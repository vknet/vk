using System;
using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model;

/// <summary>
/// Информация о географическом месте, в котором была сделана запись.
/// См. описание <see href="http://vk.com/pages?oid=-1&amp;p=Описание_поля_geo" />.
/// </summary>
[Serializable]
public class Geo
{
	/// <summary>
	/// Имя типа информации о географическом месте (в настоящий момент поддерживается
	/// единственный тип "place", это
	/// означает,
	/// что запись привязана к определенному географическому месту в базе мест.)
	/// </summary>
	[JsonProperty("type")]
	public string Type { get; set; }

	/// <summary>
	/// Координаты места, в котором была сделана запись.
	/// </summary>
	[JsonProperty("coordinates")]
	[JsonConverter(typeof(CoordinatesJsonConverter))]
	public Coordinates Coordinates { get; set; }

	/// <summary>
	/// Информация о месте, в котором была сделана запись.
	/// </summary>
	[JsonProperty("place")]
	public Place Place { get; set; }
}