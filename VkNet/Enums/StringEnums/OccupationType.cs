using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Информация о текущем роде занятия пользователя.
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
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