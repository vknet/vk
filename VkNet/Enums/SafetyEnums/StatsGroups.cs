using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Группы статистики
/// </summary>
[Serializable]
[JsonConverter(typeof(SafetyEnumJsonConverter))]
public class StatsGroups : SafetyEnum<StatsGroups>
{
	/// <summary>
	/// Посетители
	/// </summary>
	[EnumMember(Value = "visitors")]
	public static readonly StatsGroups Visitors = RegisterPossibleValue("visitors");

	/// <summary>
	/// Посетители
	/// </summary>
	[EnumMember(Value = "reach")]
	public static readonly StatsGroups Reach = RegisterPossibleValue("reach");

	/// <summary>
	/// Посетители
	/// </summary>
	[EnumMember(Value = "activity")]
	public static readonly StatsGroups Activity = RegisterPossibleValue("activity");
}