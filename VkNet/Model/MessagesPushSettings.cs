using System;
using Newtonsoft.Json;

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
}