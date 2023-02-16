using System.Runtime.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// предпочтительный способ отображения контента
/// </summary>
public class VideoView : SafetyEnum<VideoView>
{
	/// <summary>
	/// горизонтально с дополнительной информацией
	/// </summary>
	[EnumMember(Value = "horizontal")]
	public static readonly VideoView Horizontal = RegisterPossibleValue(value: "horizontal");

	/// <summary>
	/// оризонтально без дополнительной информации
	/// </summary>
	[EnumMember(Value = "horizontal_compact")]
	public static readonly VideoView HorizontalCompact = RegisterPossibleValue(value: "horizontal_compact");

	/// <summary>
	/// вертикально с дополнительной информацией
	/// </summary>
	[EnumMember(Value = "vertical")]
	public static readonly VideoView Vertical = RegisterPossibleValue(value: "vertical");

	/// <summary>
	/// вертикально с дополнительной информацией
	/// </summary>
	[EnumMember(Value = "vertical_compact")]
	public static readonly VideoView VerticalCompact = RegisterPossibleValue(value: "vertical_compact");
}