using System.Runtime.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Радиус поиска в метрах.
/// </summary>
public sealed class PhotoSearchRadius : SafetyEnum<PhotoSearchRadius>
{
	/// <summary>
	/// 10.
	/// </summary>
	[EnumMember(Value = "10")]
	public static readonly PhotoSearchRadius Ten = RegisterPossibleValue(value: "10");

	/// <summary>
	/// 100.
	/// </summary>
	[EnumMember(Value = "100")]
	public static readonly PhotoSearchRadius OneHundred = RegisterPossibleValue(value: "100");

	/// <summary>
	/// 800.
	/// </summary>
	[EnumMember(Value = "800")]
	public static readonly PhotoSearchRadius Eighty = RegisterPossibleValue(value: "800");

	/// <summary>
	/// 6000.
	/// </summary>
	[EnumMember(Value = "6000")]
	public static readonly PhotoSearchRadius SixThousand = RegisterPossibleValue(value: "6000");

	/// <summary>
	/// 50000.
	/// </summary>
	[EnumMember(Value = "50000")]
	public static readonly PhotoSearchRadius FiftyThousand = RegisterPossibleValue(value: "50000");
}