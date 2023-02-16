using System.Runtime.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Порядок сортировки комментариев к записи.
/// </summary>
public sealed class CommentsSort : SafetyEnum<CommentsSort>
{
	/// <summary>
	/// В хронологическом порядке (от старых к новым).
	/// </summary>
	[EnumMember(Value = "asc")]
	public static readonly CommentsSort Asc = RegisterPossibleValue(value: "asc");

	/// <summary>
	/// В порядке, обратном хронологическому (от новых к старым).
	/// </summary>
	[EnumMember(Value = "desc")]
	public static readonly CommentsSort Desc = RegisterPossibleValue(value: "desc");
}