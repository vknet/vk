using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Текущий статус запроса
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
public enum AdRequestStatus
{
	/// <summary>
	/// Поиск выполняется.
	/// </summary>
	SearchInProgress,

	/// <summary>
	/// Поиск завершён.
	/// </summary>
	SearchDone,

	/// <summary>
	/// Ошибка поиска.
	/// </summary>
	SearchFailed,

	/// <summary>
	/// Сохранение выполняется.
	/// </summary>
	SaveInProgress,

	/// <summary>
	/// Сохранение завершено.
	/// </summary>
	SaveDone,

	/// <summary>
	/// Ошибка сохранения.
	/// </summary>
	SaveFailed
}