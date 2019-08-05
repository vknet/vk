using System;
using VkNet.Utils;

namespace VkNet.Enums.SafetyEnums
{
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
		public static readonly ScheduleWorkInfoStatus NoInformation = RegisterPossibleValue("no_information");

		/// <summary>
		/// Открыто круглосуточно
		/// </summary>
		public static readonly ScheduleWorkInfoStatus AlwaysOpened = RegisterPossibleValue("always_opened");

		/// <summary>
		/// закрыто навсегда
		/// </summary>
		public static readonly ScheduleWorkInfoStatus ForeverClosed = RegisterPossibleValue("forever_closed");

		/// <summary>
		/// Открыто в указанные часы работы.
		/// </summary>
		public static readonly ScheduleWorkInfoStatus Timetable = RegisterPossibleValue("timetable");
	}
}