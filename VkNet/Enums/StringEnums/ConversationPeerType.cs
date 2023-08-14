using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Тип пира беседы
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
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