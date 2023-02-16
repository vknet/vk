using System.Runtime.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Уровень полномочий пользователя в сообществе (Используется для задания
/// полномочий пользователя в методе
/// EditManager).
/// </summary>
public class ManagerRole : SafetyEnum<ManagerRole>
{
	/// <summary>
	/// Создатель сообщества
	/// </summary>
	[EnumMember(Value = "creator")]
	public static readonly ManagerRole Creator = RegisterPossibleValue(value: "creator");

	/// <summary>
	/// Пользователь является администратором сообщества.
	/// </summary>
	[EnumMember(Value = "administrator")]
	public static readonly ManagerRole Administrator = RegisterPossibleValue(value: "administrator");

	/// <summary>
	/// Пользователь является модератором собщества.
	/// </summary>
	[EnumMember(Value = "moderator")]
	public static readonly ManagerRole Moderator = RegisterPossibleValue(value: "moderator");

	/// <summary>
	/// Пользователь является редактором сообщества.
	/// </summary>
	[EnumMember(Value = "editor")]
	public static readonly ManagerRole Editor = RegisterPossibleValue(value: "editor");
}