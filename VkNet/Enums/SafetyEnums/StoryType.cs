namespace VkNet.Enums.SafetyEnums;

/// <inheritdoc />
public class StoryType : SafetyEnum<StoryType>
{
	/// <summary>
	/// Фотография
	/// </summary>
	public static readonly StoryType Photo = RegisterPossibleValue("photo");

	/// <summary>
	/// Видеозапись
	/// </summary>
	public static readonly StoryType Video = RegisterPossibleValue("video");
}