using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model;

/// <summary>
/// Валюта.
/// </summary>
[Serializable]
public class Currency
{
	/// <summary>
	/// Идентификатор валюты
	/// </summary>
	[JsonProperty("id")]
	public long? Id { get; set; }

	/// <summary>
	/// Буквенное обозначение валюты
	/// </summary>
	[Obsolete(ObsoleteText.ObsoleteCyrillicProperty)]
	[JsonProperty("currency")]
	public string Сurrency { get; set; }

	/// <summary>
	/// Буквенное обозначение валюты
	/// </summary>
	[JsonProperty("name")]
	public string Name { get; set; }
}