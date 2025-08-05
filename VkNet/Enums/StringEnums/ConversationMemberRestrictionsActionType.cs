using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Ограничения участников разговора
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
public enum ConversationMemberRestrictionsActionType
{
	/// <summary>
	/// Read/write, пользователь может читать и отправлять сообщения в чат
	/// </summary>
	Rw,

	/// <summary>
	/// Read only, пользователь не может отправлять сообщения в чат
	/// </summary>
	Ro
}