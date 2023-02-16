using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Тип актиновсти в диалоге.
/// </summary>
[Serializable]
[JsonConverter(typeof(SafetyEnumJsonConverter))]
public class MessageActivityType : SafetyEnum<MessageActivityType>
{
	/// <summary>
	/// Пользователь начал набирать текст.
	/// </summary>
	[EnumMember(Value = "typing")]
	public static readonly MessageActivityType Typing = RegisterPossibleValue("typing");

	/// <summary>
	/// Пользователь записывает голосовое сообщение.
	/// </summary>
	[EnumMember(Value = "audiomessage")]
	public static readonly MessageActivityType AudioMessage = RegisterPossibleValue("audiomessage");

	/// <summary>
	/// Пользователь отправляет фото.
	/// </summary>
	[EnumMember(Value = "photo")]
	public static readonly MessageActivityType Photo = RegisterPossibleValue("photo");

	/// <summary>
	/// Пользователь отправляет видео.
	/// </summary>
	[EnumMember(Value = "video")]
	public static readonly MessageActivityType Video = RegisterPossibleValue("video");
}