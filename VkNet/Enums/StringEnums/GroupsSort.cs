using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Порядок сортировки членов группы.
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
public enum GroupsSort
{
	/// <summary>
	/// По возрастанию численных значений идентификаторов.
	/// </summary>
	IdAsc,

	/// <summary>
	/// По убыванию численных значений идентификаторов.
	/// </summary>
	IdDesc,

	/// <summary>
	/// По возрастанию времени присоединения к группе.
	/// </summary>
	TimeAsc,

	/// <summary>
	/// По убыванию времени присоединения к группе.
	/// </summary>
	TimeDesc
}