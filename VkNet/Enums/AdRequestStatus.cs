using System.Runtime.Serialization;

namespace VkNet.Enums;

/// <summary>
/// Текущий статус запроса
/// </summary>
public enum AdRequestStatus
{
	/// <summary>
	/// Поиск выполняется.
	/// </summary>
	[EnumMember(Value = "search_in_progress")]
	SearchInProgress,

	/// <summary>
	/// Поиск завершён.
	/// </summary>
	[EnumMember(Value = "search_done")]
	SearchDone,

	/// <summary>
	/// Ошибка поиска.
	/// </summary>
	[EnumMember(Value = "search_failed")]
	SearchFailed,

	/// <summary>
	/// Сохранение выполняется.
	/// </summary>
	[EnumMember(Value = "save_in_progress")]
	SaveInProgress,

	/// <summary>
	/// Сохранение завершено.
	/// </summary>
	[EnumMember(Value = "save_done")]
	SaveDone,

	/// <summary>
	/// Ошибка сохранения.
	/// </summary>
	[EnumMember(Value = "save_failed")]
	SaveFailed
}