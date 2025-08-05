using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Фильтр статуса продуктов
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
public enum ProductStatusFilter
{
	/// <summary>
	/// Купленные
	/// </summary>
	Purchased,

	/// <summary>
	/// Активные
	/// </summary>
	Active,

	/// <summary>
	/// Рекламные
	/// </summary>
	Promoted
}