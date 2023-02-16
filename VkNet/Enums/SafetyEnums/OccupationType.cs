using System;
using System.Runtime.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Информация о текущем роде занятия пользователя.
/// </summary>
[Serializable]
public sealed class OccupationType : SafetyEnum<OccupationType>
{
	/// <summary>
	/// Работа.
	/// </summary>
	[EnumMember(Value = "work")]
	public static readonly OccupationType Work = RegisterPossibleValue(value: "work");

	/// <summary>
	/// Школа.
	/// </summary>
	[EnumMember(Value = "school")]
	public static readonly OccupationType School = RegisterPossibleValue(value: "school");

	/// <summary>
	/// ВУЗ.
	/// </summary>
	[EnumMember(Value = "university")]
	public static readonly OccupationType University = RegisterPossibleValue(value: "university");
}