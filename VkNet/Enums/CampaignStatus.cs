using VkNet.Utils;

namespace VkNet.Enums;

/// <summary>
/// Статус кампании.
/// </summary>
public enum CampaignStatus
{
	/// <summary>
	/// Кампания остановлена
	/// </summary>
	[VkNetDefaultValue]
	Stopped = 0,

	/// <summary>
	/// Кампания запущена
	/// </summary>
	Started = 1,

	/// <summary>
	/// Кампания удалена
	/// </summary>
	Deleted = 2
}