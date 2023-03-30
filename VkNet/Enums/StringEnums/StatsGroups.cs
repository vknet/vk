using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Группы статистики
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
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