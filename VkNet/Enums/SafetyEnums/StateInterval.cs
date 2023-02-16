using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Единица времени для подсчета статистики.
/// </summary>
[Serializable]
[JsonConverter(typeof(SafetyEnumJsonConverter))]
public class StateInterval : SafetyEnum<StateInterval>
{
	/// <summary>
	/// День
	/// </summary>
	[DefaultValue]
	[EnumMember(Value = "day")]
	public static readonly StateInterval Day = RegisterPossibleValue("day");

	/// <summary>
	/// Неделя
	/// </summary>
	[EnumMember(Value = "week")]
	public static readonly StateInterval Week = RegisterPossibleValue("week");

	/// <summary>
	/// Месяц
	/// </summary>
	[EnumMember(Value = "month")]
	public static readonly StateInterval Month = RegisterPossibleValue("month");

	/// <summary>
	/// Все время с момента создания ссылки
	/// </summary>
	[EnumMember(Value = "year")]
	public static readonly StateInterval Year = RegisterPossibleValue("year");

	/// <summary>
	/// Все время с момента создания ссылки
	/// </summary>
	[EnumMember(Value = "all")]
	public static readonly StateInterval All = RegisterPossibleValue("all");
}