using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Информация о покупател.
/// </summary>
[Serializable]
public class Recipient
{
	/// <summary>
	/// имя покупателя.
	/// </summary>
	[JsonProperty("name")]
	public string Name { get; set; }

	/// <summary>
	/// номер покупателя..
	/// </summary>
	[JsonProperty("phone")]
	public string Phone { get; set; }

	/// <summary>
	///  строковое представление информации о покупателе.
	/// </summary>
	[JsonProperty("display_text")]
	public string DisplayText  { get; set; }

}