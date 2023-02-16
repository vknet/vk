using System;
using System.Runtime.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Тип пира беседы
/// </summary>
[Serializable]
public class ConversationPeerType : SafetyEnum<ConversationPeerType>
{
	/// <summary>
	/// Пользователь.
	/// </summary>
	[EnumMember(Value = "user")]
	public static readonly ConversationPeerType User = RegisterPossibleValue("user");

	/// <summary>
	/// Чат.
	/// </summary>
	[EnumMember(Value = "chat")]
	public static readonly ConversationPeerType Chat = RegisterPossibleValue("chat");

	/// <summary>
	/// Группа.
	/// </summary>
	[EnumMember(Value = "group")]
	public static readonly ConversationPeerType Group = RegisterPossibleValue("group");

	/// <summary>
	/// E-mail.
	/// </summary>
	[EnumMember(Value = "email")]
	public static readonly ConversationPeerType Email = RegisterPossibleValue("email");
}