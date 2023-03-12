using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Тип страницы.
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
public enum FavePageType
{
	/// <summary>
	/// Пользователи.
	/// </summary>
	Users,

	/// <summary>
	/// Сообщества.
	/// </summary>
	Groups,

	/// <summary>
	/// Топ сообществ и пользователей.
	/// </summary>
	Hints
}