using Newtonsoft.Json;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Тип расписания.
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
public enum ScheduleWorkInfoStatus
{
	/// <summary>
	/// Нет информации о расписании
	/// </summary>
	[VkNetDefaultValue]
	 NoInformation,

	/// <summary>
	/// Открыто круглосуточно
	/// </summary>
	AlwaysOpened,

	/// <summary>
	/// закрыто навсегда
	/// </summary>
	ForeverClosed,

	/// <summary>
	/// Открыто в указанные часы работы.
	/// </summary>
	Timetable
}