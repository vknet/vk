using Newtonsoft.Json;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Единица времени для подсчета статистики.
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
public enum StateInterval
{
	/// <summary>
	/// День
	/// </summary>
	[VkNetDefaultValue]
	Day,

	/// <summary>
	/// Неделя
	/// </summary>
	Week,

	/// <summary>
	/// Месяц
	/// </summary>
	Month,

	/// <summary>
	/// Все время с момента создания ссылки
	/// </summary>
	Year,

	/// <summary>
	/// Все время с момента создания ссылки
	/// </summary>
	All
}