using System;
using System.Runtime.Serialization;
using VkNet.Utils;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Тип расписания.
/// </summary>
[Serializable]
public class ScheduleWorkInfoStatus : SafetyEnum<ScheduleWorkInfoStatus>
{
	/// <summary>
	/// Нет информации о расписании
	/// </summary>
	[DefaultValue]
	[EnumMember(Value = "no_information")]
	public static readonly ScheduleWorkInfoStatus NoInformation = RegisterPossibleValue("no_information");

	/// <summary>
	/// Открыто круглосуточно
	/// </summary>
	[EnumMember(Value = "always_opened")]
	public static readonly ScheduleWorkInfoStatus AlwaysOpened = RegisterPossibleValue("always_opened");

	/// <summary>
	/// закрыто навсегда
	/// </summary>
	[EnumMember(Value = "forever_closed")]
	public static readonly ScheduleWorkInfoStatus ForeverClosed = RegisterPossibleValue("forever_closed");

	/// <summary>
	/// Открыто в указанные часы работы.
	/// </summary>
	[EnumMember(Value = "timetable")]
	public static readonly ScheduleWorkInfoStatus Timetable = RegisterPossibleValue("timetable");
}