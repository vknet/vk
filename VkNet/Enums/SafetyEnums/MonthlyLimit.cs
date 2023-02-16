using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.SafetyEnums;

/// <inheritdoc />
/// <summary>
/// Месячные ограничения
/// </summary>
[Serializable]
[JsonConverter(converterType: typeof(SafetyEnumJsonConverter))]
public class MonthlyLimit : SafetyEnum<MonthlyLimit>
{
	/// <summary>
	/// 1 месяц.
	/// </summary>
	[EnumMember(Value = "tier_1")]
	public static readonly MonthlyLimit Tier1 = RegisterPossibleValue(value: "tier_1");

	/// <summary>
	/// 2 месяца.
	/// </summary>
	[EnumMember(Value = "tier_2")]
	public static readonly MonthlyLimit Tier2 = RegisterPossibleValue(value: "tier_2");

	/// <summary>
	/// 3 месяца.
	/// </summary>
	[EnumMember(Value = "tier_3")]
	public static readonly MonthlyLimit Tier3 = RegisterPossibleValue(value: "tier_3");

	/// <summary>
	/// 4 месяца.
	/// </summary>
	[EnumMember(Value = "tier_4")]
	public static readonly MonthlyLimit Tier4 = RegisterPossibleValue(value: "tier_4");

	/// <summary>
	/// 5 месяцев.
	/// </summary>
	[EnumMember(Value = "tier_5")]
	public static readonly MonthlyLimit Tier5 = RegisterPossibleValue(value: "tier_5");

	/// <summary>
	/// 6 месяцев.
	/// </summary>
	[EnumMember(Value = "tier_6")]
	public static readonly MonthlyLimit Tier6 = RegisterPossibleValue(value: "tier_6");

	/// <summary>
	/// Безлимитный доступ.
	/// </summary>
	[EnumMember(Value = "unlimited")]
	public static readonly MonthlyLimit Unlimited = RegisterPossibleValue(value: "unlimited");
}