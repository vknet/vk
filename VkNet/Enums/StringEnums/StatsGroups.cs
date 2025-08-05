using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Группы статистики
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
public enum StatsGroups
{
	/// <summary>
	/// Посетители
	/// </summary>
	Visitors,

	/// <summary>
	/// Посетители
	/// </summary>
	Reach,

	/// <summary>
	/// Посетители
	/// </summary>
	Activity
}