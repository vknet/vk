﻿using System.Runtime.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Порядок сортировки членов группы.
/// </summary>
public sealed class GroupsSort : SafetyEnum<GroupsSort>
{
	/// <summary>
	/// По возрастанию численных значений идентификаторов.
	/// </summary>
	[EnumMember(Value = "id_asc")]
	public static readonly GroupsSort IdAsc = RegisterPossibleValue(value: "id_asc");

	/// <summary>
	/// По убыванию численных значений идентификаторов.
	/// </summary>
	[EnumMember(Value = "id_desc")]
	public static readonly GroupsSort IdDesc = RegisterPossibleValue(value: "id_desc");

	/// <summary>
	/// По возрастанию времени присоединения к группе.
	/// </summary>
	[EnumMember(Value = "time_asc")]
	public static readonly GroupsSort TimeAsc = RegisterPossibleValue(value: "time_asc");

	/// <summary>
	/// По убыванию времени присоединения к группе.
	/// </summary>
	[EnumMember(Value = "time_desc")]
	public static readonly GroupsSort TimeDesc = RegisterPossibleValue(value: "time_desc");
}