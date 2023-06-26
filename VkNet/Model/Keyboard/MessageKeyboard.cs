using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Объект клавиатуры, отправляемой ботом.
/// </summary>
[Serializable]
[JsonObject(MemberSerialization.OptOut)]
public class MessageKeyboard
{
	/// <summary>
	/// Скрыть клавиатуру сразу же после нажатия на кнопку.
	/// </summary>
	[JsonProperty(propertyName: "one_time")]
	public bool OneTime { get; set; }

	/// <summary>
	/// Должна ли клавиатура отображаться внутри сообщения.
	/// </summary>
	[JsonProperty(propertyName: "inline")]
	public bool Inline { get; set; }

	/// <summary>
	/// Массив кнопок отправляемых ботом, размером до 4х10
	/// </summary>
	[JsonProperty(propertyName: "buttons")]
	public IEnumerable<IEnumerable<MessageKeyboardButton>> Buttons { get; set; }
}