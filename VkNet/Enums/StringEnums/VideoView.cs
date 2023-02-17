using System.Runtime.Serialization;

namespace VkNet.Enums;

/// <summary>
/// предпочтительный способ отображения контента
/// </summary>
public enum VideoView
{
	/// <summary>
	/// горизонтально с дополнительной информацией
	/// </summary>
	[EnumMember(Value = "horizontal")]
	Horizontal,

	/// <summary>
	/// оризонтально без дополнительной информации
	/// </summary>
	[EnumMember(Value = "horizontal_compact")]
	HorizontalCompact,

	/// <summary>
	/// вертикально с дополнительной информацией
	/// </summary>
	[EnumMember(Value = "vertical")]
	Vertical,

	/// <summary>
	/// вертикально с дополнительной информацией
	/// </summary>
	[EnumMember(Value = "vertical_compact")]
	VerticalCompact
}