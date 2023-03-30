using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Настройки беседы
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
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