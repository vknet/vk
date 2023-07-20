using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Тип фона опроса.
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
public enum PollBackgroundType
{
	/// <summary>
	/// Gradient.
	/// </summary>
	Gradient,

	/// <summary>
	/// tile.
	/// </summary>
	Tile
}