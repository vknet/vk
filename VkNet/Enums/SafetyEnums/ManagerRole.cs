using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Уровень полномочий пользователя в сообществе (Используется для задания
/// полномочий пользователя в методе
/// EditManager).
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
public enum ManagerRole
{
	/// <summary>
	/// Создатель сообщества
	/// </summary>
	Creator,

	/// <summary>
	/// Пользователь является администратором сообщества.
	/// </summary>
	Administrator,

	/// <summary>
	/// Пользователь является модератором собщества.
	/// </summary>
	Moderator,

	/// <summary>
	/// Пользователь является редактором сообщества.
	/// </summary>
	Editor
}