using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Настройки беседы
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
public enum ConversationChatSettingsState
{
	/// <summary>
	/// Состоит в чате.
	/// </summary>
	In,

	/// <summary>
	/// Исключён из чата.
	/// </summary>
	Kicked,

	/// <summary>
	/// Покинул чат.
	/// </summary>
	Left
}