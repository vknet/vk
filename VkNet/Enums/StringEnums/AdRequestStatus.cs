using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Текущий статус запроса
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
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