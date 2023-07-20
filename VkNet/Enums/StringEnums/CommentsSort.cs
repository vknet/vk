using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Порядок сортировки комментариев к записи.
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
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