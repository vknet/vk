using Newtonsoft.Json;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Фильтр беседы
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
public enum GetConversationFilter
{
	/// <summary>
	/// Все беседы.
	/// </summary>
	[VkNetDefaultValue]
	All,

	/// <summary>
	/// Беседы с непрочитанными сообщениями;
	/// </summary>
	Unread,

	/// <summary>
	/// Беседы, помеченные как важные (только для сообщений сообществ);
	/// </summary>
	Important,

	/// <summary>
	/// Беседы, помеченные как неотвеченные (только для сообщений сообществ).
	/// </summary>
	Unanswered
}