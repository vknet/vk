using System;
using System.Runtime.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Тип родственных связей.
/// </summary>
[Serializable]
public sealed class RelativeType : SafetyEnum<RelativeType>
{
	/// <summary>
	/// Брат/Сестра.
	/// </summary>
	[EnumMember(Value = "sibling")]
	public static readonly RelativeType Sibling = RegisterPossibleValue(value: "sibling");

	/// <summary>
	/// Родитель.
	/// </summary>
	[EnumMember(Value = "parent")]
	public static readonly RelativeType Parent = RegisterPossibleValue(value: "parent");

	/// <summary>
	/// Ребенок.
	/// </summary>
	[EnumMember(Value = "child")]
	public static readonly RelativeType Child = RegisterPossibleValue(value: "child");

	/// <summary>
	/// Дедушка/Бабушка.
	/// </summary>
	[EnumMember(Value = "grandparent")]
	public static readonly RelativeType Grandparent = RegisterPossibleValue(value: "grandparent");

	/// <summary>
	/// Внук.
	/// </summary>
	[EnumMember(Value = "grandchild")]
	public static readonly RelativeType Grandchild = RegisterPossibleValue(value: "grandchild");
}