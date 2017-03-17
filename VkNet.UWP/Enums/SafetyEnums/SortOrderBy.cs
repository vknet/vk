using VkNet.Enums.SafetyEnums;

namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Порядок сортировки
	/// </summary>
	public sealed class SortOrderBy : SafetyEnum<SortOrderBy>
	{
		/// <summary>
		/// По убыванию
		/// </summary>
		public static readonly SortOrderBy Desc = RegisterPossibleValue("desc");

		/// <summary>
		/// По возрастанию
		/// </summary>
		public static readonly SortOrderBy Asc = RegisterPossibleValue("asc");
	}
}