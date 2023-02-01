﻿using System;
using Newtonsoft.Json;
using VkNet.Utils;

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

	/// <summary>
	/// Разобрать из json.
	/// </summary>
	/// <param name="response"> Ответ сервера. </param>
	/// <returns> </returns>
	public static Contacts FromJson(VkResponse response)
	{
		var contacts = new Contacts
		{
			MobilePhone = response[key: "mobile_phone"],
			HomePhone = response[key: "home_phone"]
		};

		return contacts;
	}
}