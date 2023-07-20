using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// предпочтительный способ отображения контента
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
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