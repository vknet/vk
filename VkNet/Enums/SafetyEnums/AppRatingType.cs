using System.Runtime.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Рейтинг приложений
/// </summary>
public sealed class AppRatingType : SafetyEnum<AppRatingType>
{
	/// <summary>
	/// Рейтинг по уровням
	/// </summary>
	[EnumMember(Value = "level")]
	public static readonly AppRatingType Level = RegisterPossibleValue(value: "level");

	/// <summary>
	/// Рейтинг по очкам
	/// </summary>
	[EnumMember(Value = "points")]
	public static readonly AppRatingType Points = RegisterPossibleValue(value: "points");
}