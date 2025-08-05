using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Доступность значения.
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
public enum StoryObjectState
{
	/// <summary>
	/// Доступно.
	/// </summary>
	On,

	/// <summary>
	/// Недоступно.
	/// </summary>
	Off,

	/// <summary>
	/// Недоступно.
	/// </summary>
	Hidden
}