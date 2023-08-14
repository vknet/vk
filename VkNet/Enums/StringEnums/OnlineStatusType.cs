using Newtonsoft.Json;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Информация о текущем роде занятия пользователя.
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
public enum OnlineStatusType
{
	/// <summary>
	/// Сообщество не онлайн
	/// </summary>
	[VkNetDefaultValue]
	None,

	/// <summary>
	/// Сообщество онлайн (отвечает мгновенно)
	/// </summary>
	Online,

	/// <summary>
	/// Сообщество отвечает быстро.
	/// </summary>
	AnswerMark
}