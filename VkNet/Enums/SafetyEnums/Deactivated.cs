using System;
using System.Runtime.Serialization;
using VkNet.Utils;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Возможные значения параметра Deactivated.
/// </summary>
[Serializable]
public sealed class Deactivated : SafetyEnum<Deactivated>
{
	/// <summary>
	/// Удалено.
	/// </summary>
	[EnumMember(Value = "deleted")]
	public static readonly Deactivated Deleted = RegisterPossibleValue(value: "deleted");

	/// <summary>
	/// Заблокировано.
	/// </summary>
	[EnumMember(Value = "banned")]
	public static readonly Deactivated Banned = RegisterPossibleValue(value: "banned");

	/// <summary>
	/// Активно.
	/// </summary>
	[DefaultValue]
	[EnumMember(Value = "activated")]
	public static readonly Deactivated Activated = RegisterPossibleValue(value: "activated");
}