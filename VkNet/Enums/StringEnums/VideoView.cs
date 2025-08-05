using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// предпочтительный способ отображения контента
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
public enum VideoView
{
	/// <summary>
	/// горизонтально с дополнительной информацией
	/// </summary>
	Horizontal,

	/// <summary>
	/// оризонтально без дополнительной информации
	/// </summary>
	HorizontalCompact,

	/// <summary>
	/// вертикально с дополнительной информацией
	/// </summary>
	Vertical,

	/// <summary>
	/// вертикально с дополнительной информацией
	/// </summary>
	VerticalCompact
}