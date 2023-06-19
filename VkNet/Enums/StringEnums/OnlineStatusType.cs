using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using VkNet.Utils;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Информация о текущем роде занятия пользователя.
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
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