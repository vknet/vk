using VkNet.Utils;

namespace VkNet.Enums;

/// <summary>
/// Возрастные ограничения
/// </summary>
public enum AgeLimit
{
	/// <summary>
	/// Нет ограничений
	/// </summary>
	[VkNetDefaultValue]
	Withoutlimit = 1,

	/// <summary>
	/// 16+
	/// </summary>
	Sixteen = 2,

	/// <summary>
	/// 18+
	/// </summary>
	Eighteen
}