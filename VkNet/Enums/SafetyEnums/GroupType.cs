using System;
using System.Runtime.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Тип сообщества
/// </summary>
[Serializable]
public sealed class GroupType : SafetyEnum<GroupType>
{
	/// <summary>
	/// Публичная страница.
	/// </summary>
	[EnumMember(Value = "page")]
	public static readonly GroupType Page = RegisterPossibleValue(value: "page");

	/// <summary>
	/// Группа.
	/// </summary>
	[EnumMember(Value = "group")]
	public static readonly GroupType Group = RegisterPossibleValue(value: "group");

	/// <summary>
	/// Мероприятие.
	/// </summary>
	[EnumMember(Value = "event")]
	public static readonly GroupType Event = RegisterPossibleValue(value: "event");

	/// <summary>
	/// Не определено.
	/// </summary>
	[EnumMember(Value = "undefined")]
	public static readonly GroupType Undefined = RegisterPossibleValue(value: "undefined");
}