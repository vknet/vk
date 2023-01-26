using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Магазин.
/// </summary>
[Serializable]
public class Store
{
	/// <summary>
	/// Идентификатор магазина;.
	/// </summary>
	[JsonProperty("id")]
	public long? Id { get; set; }

	/// <summary>
	/// Название магазина;.
	/// </summary>
	[JsonProperty("name")]
	public string Name { get; set; }
}