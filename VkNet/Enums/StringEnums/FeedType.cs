using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Порядок сортировки членов группы.
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
public enum FeedType
{
	/// <summary>
	/// По возрастанию численных значений идентификаторов.
	/// </summary>
	Photo,

	/// <summary>
	/// По убыванию численных значений идентификаторов.
	/// </summary>
	PhotoTag
}