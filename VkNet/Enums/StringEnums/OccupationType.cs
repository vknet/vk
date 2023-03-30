using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Информация о текущем роде занятия пользователя.
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
public enum OccupationType
{
	/// <summary>
	/// Работа.
	/// </summary>
	Work,

	/// <summary>
	/// Школа.
	/// </summary>
	School,

	/// <summary>
	/// ВУЗ.
	/// </summary>
	University
}