using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Информация о доставке
/// </summary>
[Serializable]
public class Delivery
{
	/// <summary>
	/// адрес доставки.
	/// </summary>
	[JsonProperty("address")]
	public string Address { get; set; }

	/// <summary>
	/// тип доставки.
	/// </summary>
	[JsonProperty("type")]
	public string Type { get; set; }

	/// <summary>
	/// трек-номер для отслеживания заказа.
	/// </summary>
	[JsonProperty("track_number")]
	public string TrackNumber { get; set; }

	/// <summary>
	///  ссылка для отслеживания заказа по трек-номеру.
	/// </summary>
	[JsonProperty("track_link")]
	public string TrackLink { get; set; }

	/// <summary>
	/// информация о пункте выдачи.
	/// </summary>
	[JsonProperty("delivery_point ")]
	public string DeliveryPoint  { get; set; }
}