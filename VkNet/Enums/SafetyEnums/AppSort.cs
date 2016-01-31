﻿using VkNet.Enums.SafetyEnums;
using VkNet.Utils;

namespace VkNet.Enums
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
		public static readonly AppSort PopularToday = RegisterPossibleValue("popular_today");

		/// <summary>
		/// По посещаемости
		/// </summary>
		public static readonly AppSort Visitors = RegisterPossibleValue("visitors");

		/// <summary>
		/// По дате создания приложения
		/// </summary>
		public static readonly AppSort CreateDate = RegisterPossibleValue("create_date");

		/// <summary>
		/// По скорости роста
		/// </summary>
		public static readonly AppSort GrowthRate = RegisterPossibleValue("growth_rate");

		/// <summary>
		/// Популярные за неделю.
		/// </summary>
		public static readonly AppSort PopularWeek = RegisterPossibleValue("popular_week");
	}
}