using System;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Enums;
using VkNet.Enums.StringEnums;

namespace VkNet.Model;

/// <summary>
/// Информация об адресах сообщества.
/// </summary>
[DebuggerDisplay(value: "[{MainAddressId}] ({Count})")]
[Serializable]
public class Addresses
{
	/// <summary>
	/// Включен ли блок адресов в сообществе.
	/// </summary>
	[JsonProperty(propertyName: "is_enabled")]
	public bool? IsEnabled { get; set; }

	/// <summary>
	/// Идентификатор главного адреса.
	/// </summary>
	[JsonProperty(propertyName: "main_address_id")]
	public long? MainAddressId { get; set; }

	/// <summary>
	/// Общее количество адресов.
	/// </summary>
	[JsonProperty(propertyName: "count")]
	public long? Count { get; set; }

	/// <summary>
	/// Информация о главном адресе.
	/// </summary>
	[JsonProperty(propertyName: "main_address")]
	public Address MainAddress { get; set; }
}
