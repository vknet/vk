using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Порядок сортировки членов группы.
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
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