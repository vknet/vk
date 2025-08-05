using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Тип фона опроса.
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
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