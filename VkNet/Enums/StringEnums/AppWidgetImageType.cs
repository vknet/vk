using System.Runtime.Serialization;

namespace VkNet.Enums;

/// <summary>
/// Тип изображения для виджета приложения
/// </summary>
public enum AppWidgetImageType
{
	/// <summary>
	/// 24x24
	/// </summary>
	[EnumMember(Value = "24x24")]
	TwentyFourOnTwentyFour,

	/// <summary>
	/// 50x50
	/// </summary>
	[EnumMember(Value = "50x50")]
	FiftyOnFifty,

	/// <summary>
	/// 160x160
	/// </summary>
	[EnumMember(Value = "160x160")]
	OneHundredAndSixtyOnOneHundredAndSixty,

	/// <summary>
	/// 160x240
	/// </summary>
	[EnumMember(Value = "160x240")]
	OneHundredAndSixtyOnTwoHundredAndForty,

	/// <summary>
	/// 510x128
	/// </summary>
	[EnumMember(Value = "510x128")]
	FiveHundredAndTenOnOneHundredAndTwentyEight
}