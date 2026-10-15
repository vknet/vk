using System;
using System.Diagnostics;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Город адреса.
/// </summary>
[DebuggerDisplay(value: "[{Id}] ({Title})")]
[Serializable]
public class AddressCity
{
	/// <summary>
	/// Идентификатор города.
	/// </summary>
	[JsonProperty(propertyName: "id")]
	public long? Id { get; set; }

	/// <summary>
	/// Название города.
	/// </summary>
	[JsonProperty(propertyName: "title")]
	public string Title { get; set; }
}
