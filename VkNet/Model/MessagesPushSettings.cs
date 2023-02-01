﻿using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model;

/// <summary>
/// Настройки уведомлений для сообщений
/// </summary>
[Serializable]
public class MessagesPushSettings
{
	/// <summary>
	/// Отключить звук.
	/// </summary>
	[JsonProperty("no_sound")]
	public bool NoSound { get; set; }

	/// <summary>
	/// Не передавать текст сообщения.
	/// </summary>
	[JsonProperty("no_text")]
	public bool NoText { get; set; }

	/// <summary>
	/// Разобрать из json.
	/// </summary>
	/// <param name="response"> Ответ сервера. </param>
	/// <returns> </returns>
	public static MessagesPushSettings FromJson(VkResponse response)
	{
		var result = new MessagesPushSettings
		{
			NoSound = response[key: "no_sound"],
			NoText = response[key: "no_text"]
		};

		return result;
	}
}