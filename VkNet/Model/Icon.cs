using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Иконка
/// </summary>
[Serializable]
public class Icon
{
	/// <summary>
	/// URL иконки
	/// </summary>
	[JsonProperty("base_url")]
	public string BaseUrl { get; set; }
}