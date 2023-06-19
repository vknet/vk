using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Доступность значения.
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
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