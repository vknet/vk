using System;
using Newtonsoft.Json;
using VkNet.Utils;

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

	/// <summary>
	/// Разобрать из json.
	/// </summary>
	/// <param name="response"> Ответ сервера. </param>
	/// <returns> </returns>
	public static LookupContactsOther FromJson(VkResponse response) => new()
	{
		Contact = response[key: "contact"],
		CommonCount = response[key: "common_count"]
	};
}