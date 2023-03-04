using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Контактов, который не был найден.
/// </summary>
[Serializable]
public class LookupContactsOther
{
	/// <summary>
	/// Контакт.
	/// </summary>
	[JsonProperty("contact")]
	public string Contact { get; set; }

	/// <summary>
	/// Количество.
	/// </summary>
	[JsonProperty("common_count")]
	public long CommonCount { get; set; }
}