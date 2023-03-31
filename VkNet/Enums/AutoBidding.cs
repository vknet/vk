using VkNet.Utils;

namespace VkNet.Enums;

/// <summary>
/// Автоматическое управление ценой.
/// </summary>
public enum AutoBidding
{
	/// <summary>
	/// Выключено.
	/// </summary>
	[VkNetDefaultValue]
	Off = 0,

	/// <summary>
	/// Включено.
	/// </summary>
	On = 1
}