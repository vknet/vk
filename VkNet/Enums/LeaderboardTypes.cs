using VkNet.Utils;

namespace VkNet.Enums;

/// <summary>
/// Тип турнирной таблицы
/// </summary>
public enum LeaderboardTypes
{
	/// <summary>
	/// Не поддерживается
	/// </summary>
	[VkNetDefaultValue]
	NotSupported = 0,

	/// <summary>
	/// По уровню
	/// </summary>
	ByLevel,

	/// <summary>
	/// По очкам
	/// </summary>
	ByPoints
}