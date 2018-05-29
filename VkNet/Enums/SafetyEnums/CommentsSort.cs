namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Порядок сортировки комментариев к записи.
	/// </summary>
	public sealed class CommentsSort : SafetyEnum<CommentsSort>
	{
		/// <summary>
		/// В хронологическом порядке (от старых к новым).
		/// </summary>
		public static readonly CommentsSort Asc = RegisterPossibleValue(value: "asc");

		/// <summary>
		/// В порядке, обратном хронологическому (от новых к старым).
		/// </summary>
		public static readonly CommentsSort Desc = RegisterPossibleValue(value: "desc");
	}
}