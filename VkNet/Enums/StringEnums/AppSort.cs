using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using VkNet.Utils;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Способ сортировки приложений
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
public enum AppSort
{
	/// <summary>
	/// Популярные за день (по умолчанию);
	/// </summary>
	[DefaultValue]
	PopularToday,

	/// <summary>
	/// По посещаемости
	/// </summary>
	Visitors,

	/// <summary>
	/// По дате создания приложения
	/// </summary>
	CreateDate,

	/// <summary>
	/// По скорости роста
	/// </summary>
	GrowthRate,

	/// <summary>
	/// Популярные за неделю.
	/// </summary>
	PopularWeek
}