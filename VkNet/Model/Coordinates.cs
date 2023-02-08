using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Координаты места, в котором была сделана запись.
/// См. описание <see href="http://vk.com/pages?oid=-1&amp;p=Описание_поля_geo" />.
/// Официальная страница http://vk.com/dev/post
/// молчит о том, что возвращаются географические координаты.
/// </summary>
[Serializable]
public class Coordinates
{
	/// <summary>
	/// Географическая широта.
	/// </summary>
	[JsonProperty("latitude")]
	public double Latitude { get; set; }

	/// <summary>
	/// Географическая долгота.
	/// </summary>
	[JsonProperty("longitude")]
	public double Longitude { get; set; }
}