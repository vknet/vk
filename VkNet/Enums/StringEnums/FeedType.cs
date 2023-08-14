using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Порядок сортировки членов группы.
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
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