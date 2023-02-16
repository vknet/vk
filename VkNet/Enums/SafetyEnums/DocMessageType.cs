using System.Runtime.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// тип документа
/// </summary>
public class DocMessageType : SafetyEnum<DocMessageType>
{
	/// <summary>
	/// DocMessageType
	/// </summary>
	[EnumMember(Value = "doc")]
	public static readonly DocMessageType Doc = RegisterPossibleValue(value: "doc");

	/// <summary>
	/// голосовое сообщение
	/// </summary>
	[EnumMember(Value = "audio_message")]
	public static readonly DocMessageType AudioMessage = RegisterPossibleValue(value: "audio_message");

	/// <summary>
	/// Граффити
	/// </summary>
	[EnumMember(Value = "graffiti")]
	public static readonly DocMessageType Graffiti = RegisterPossibleValue(value: "graffiti");
}