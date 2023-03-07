namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Рейтинг приложений
/// </summary>
[StringEnum]
public enum AppRatingType
{
	/// <summary>
	/// Рейтинг по уровням
	/// </summary>
	Level,

	/// <summary>
	/// Рейтинг по очкам
	/// </summary>
	Points
}