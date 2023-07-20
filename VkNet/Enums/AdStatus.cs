using VkNet.Utils;

namespace VkNet.Enums;

/// <summary>
/// Cтатус объявления.
/// </summary>
public enum AdStatus
{
	/// <summary>
	/// Объявление остановлено
	/// </summary>
	[VkNetDefaultValue]
	Stopped = 0,

	/// <summary>
	/// Объявление запущено
	/// </summary>
	Active,

	/// <summary>
	/// Объявление удалено
	/// </summary>
	Deleted
}