using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using VkNet.Utils;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Единица времени для подсчета статистики.
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
public enum LinkStatInterval
{
	/// <summary>
	/// Час
	/// </summary>
	Hour,

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
	Forever
}