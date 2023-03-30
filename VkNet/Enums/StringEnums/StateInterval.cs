using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using VkNet.Utils;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Единица времени для подсчета статистики.
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
public enum StateInterval
{
	/// <summary>
	/// День
	/// </summary>
	[DefaultValue]
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