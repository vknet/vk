using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Тип пира беседы
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
public enum ConversationPeerType
{
	/// <summary>
	/// Пользователь.
	/// </summary>
	User,

	/// <summary>
	/// Чат.
	/// </summary>
	Chat,

	/// <summary>
	/// Группа.
	/// </summary>
	Group,

	/// <summary>
	/// E-mail.
	/// </summary>
	Email
}