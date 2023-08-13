using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Тип страницы.
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
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