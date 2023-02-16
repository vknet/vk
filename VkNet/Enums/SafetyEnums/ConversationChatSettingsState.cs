using System;
using System.Runtime.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Настройки беседы
/// </summary>
[Serializable]
public class ConversationChatSettingsState : SafetyEnum<ConversationChatSettingsState>
{
	/// <summary>
	/// Состоит в чате.
	/// </summary>
	[EnumMember(Value = "in")]
	public static readonly ConversationChatSettingsState In = RegisterPossibleValue("in");

	/// <summary>
	/// Исключён из чата.
	/// </summary>
	[EnumMember(Value = "kicked")]
	public static readonly ConversationChatSettingsState Kicked = RegisterPossibleValue("kicked");

	/// <summary>
	/// Покинул чат.
	/// </summary>
	[EnumMember(Value = "left")]
	public static readonly ConversationChatSettingsState Left = RegisterPossibleValue("left");
}