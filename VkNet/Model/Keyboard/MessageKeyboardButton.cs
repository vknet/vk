using System;
using Newtonsoft.Json;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model.Keyboard;

/// <summary>
/// Кнопка клавиатуры, отправляемая ботом.
/// </summary>
[Serializable]
[JsonObject(MemberSerialization.OptOut)]
public class MessageKeyboardButton
{
	/// <summary>
	/// Информация содержащаяся в кнопке
	/// </summary>
	[JsonProperty("action")]
	public MessageKeyboardButtonAction Action { get; set; }

	/// <summary>
	/// Цвет кнопки
	/// </summary>
	[JsonProperty("color", NullValueHandling = NullValueHandling.Ignore)]
	public KeyboardButtonColor? Color { get; set; }
}