using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Порядок сортировки комментариев к записи.
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
public enum CommentsSort
{
	/// <summary>
	/// В хронологическом порядке (от старых к новым).
	/// </summary>
	Asc,

	/// <summary>
	/// В порядке, обратном хронологическому (от новых к старым).
	/// </summary>
	Desc
}