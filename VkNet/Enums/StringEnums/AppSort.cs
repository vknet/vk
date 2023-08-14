using Newtonsoft.Json;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Способ сортировки приложений
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
public enum AppSort
{
	/// <summary>
	/// Популярные за день (по умолчанию);
	/// </summary>
	[VkNetDefaultValue]
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