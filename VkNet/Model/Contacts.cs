using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Информация о телефонных номерах пользователя.
/// </summary>
[Serializable]
public class Contacts
{
	/// <summary>
	/// Номер мобильного телефона пользователя (только для Standalone-приложений).
	/// </summary>
	[JsonProperty("mobile_phone")]
	public string MobilePhone { get; set; }

	/// <summary>
	/// Дополнительный номер телефона пользователя.
	/// </summary>
	[JsonProperty("home_phone")]
	public string HomePhone { get; set; }
}