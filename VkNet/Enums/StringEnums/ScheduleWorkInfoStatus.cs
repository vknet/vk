using System.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using VkNet.Utils;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Тип расписания.
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
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