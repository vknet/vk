using VkNet.Utils;

namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Способ сортировки приложений
	/// </summary>
	public sealed class AppSort : SafetyEnum<AppSort>
	{
		/// <summary>
		/// Популярные за день (по умолчанию);
		/// </summary>
		[DefaultValue]
		public static readonly AppSort PopularToday = RegisterPossibleValue(value: "popular_today");

		/// <summary>
		/// По посещаемости
		/// </summary>
		public static readonly AppSort Visitors = RegisterPossibleValue(value: "visitors");

		/// <summary>
		/// По дате создания приложения
		/// </summary>
		public static readonly AppSort CreateDate = RegisterPossibleValue(value: "create_date");

		/// <summary>
		/// По скорости роста
		/// </summary>
		public static readonly AppSort GrowthRate = RegisterPossibleValue(value: "growth_rate");

		/// <summary>
		/// Популярные за неделю.
		/// </summary>
		public static readonly AppSort PopularWeek = RegisterPossibleValue(value: "popular_week");
	}
}