using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// E-Mail.
/// </summary>
[Serializable]
public class Email
{
	/// <summary>
	/// Идентификатор e-mail
	/// </summary>
	[JsonProperty(propertyName: "id")]
	public int Id { get; set; }

	/// <summary>
	/// Адрес e-mail
	/// </summary>
	[JsonProperty(propertyName: "address")]
	public string Address { get; set; }
}