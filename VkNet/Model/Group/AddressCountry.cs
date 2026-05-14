using System;
using System.Diagnostics;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Страна адреса.
/// </summary>
[DebuggerDisplay(value: "[{Id}] ({Title})")]
[Serializable]
public class AddressCountry
{
	/// <summary>
	/// Идентификатор страны.
	/// </summary>
	[JsonProperty(propertyName: "id")]
	public long? Id { get; set; }

	/// <summary>
	/// Название страны.
	/// </summary>
	[JsonProperty(propertyName: "title")]
	public string Title { get; set; }
}