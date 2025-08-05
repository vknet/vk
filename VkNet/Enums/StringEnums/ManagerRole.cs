using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Уровень полномочий пользователя в сообществе (Используется для задания
/// полномочий пользователя в методе
/// EditManager).
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
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