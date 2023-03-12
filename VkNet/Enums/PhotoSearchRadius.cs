using VkNet.Utils;

namespace VkNet.Enums;

/// <summary>
/// Радиус поиска в метрах.
/// </summary>
public enum PhotoSearchRadius
{
	/// <summary>
	/// 10.
	/// </summary>
	Ten = 10,

	/// <summary>
	/// 100.
	/// </summary>
	OneHundred = 100,

	/// <summary>
	/// 800.
	/// </summary>
	EightHundred = 800,

	/// <summary>
	/// 6000.
	/// </summary>
	SixThousand = 6000,

	/// <summary>
	/// 50000.
	/// </summary>
	[DefaultValue]
	FiftyThousand = 50000
}