using System;
using System.Collections.ObjectModel;
using System.Globalization;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Статистика сообщества или приложения.
	/// </summary>
	public class StatsPeriod
	{
		/// <summary>
		/// День в формате YYYY-MM-DD.
		/// </summary>
		public DateTime Day
		{ get; set; }

		/// <summary>
		/// Количество просмотров.
		/// </summary>
		public long Views
		{ get; set; }

		/// <summary>
		/// Количество уникальных посетителей.
		/// </summary>
		public long Visitors
		{ get; set; }

		/// <summary>
		/// Полный охват.
		/// </summary>
		public long? Reach
		{ get; set; }

		/// <summary>
		/// Охват подписчиков.
		/// </summary>
		public long? ReachSubscribers
		{ get; set; }

		/// <summary>
		/// Число новых подписчиков.
		/// </summary>
		public long? Subscribed
		{ get; set; }

		/// <summary>
		/// Число отписавшихся.
		/// </summary>
		public long? Unsubscribed
		{ get; set; }

		/// <summary>
		/// Список структур, описывающих статистику по полу.
		/// </summary>
		public ReadOnlyCollection<StatsStruct> Sex
		{ get; set; }

		/// <summary>
		/// Список структур, описывающих статистику по возрасту.
		/// </summary>
		public ReadOnlyCollection<StatsStruct> Age
		{ get; set; }

		/// <summary>
		/// Список структур, описывающих статистику по полу и возрасту.
		/// </summary>
		public ReadOnlyCollection<StatsStruct> SexAge
		{ get; set; }

		/// <summary>
		/// Список структур, описывающих статистику по городам.
		/// </summary>
		public ReadOnlyCollection<StatsStruct> Cities
		{ get; set; }

		/// <summary>
		/// Список структур, описывающих статистику по странам.
		/// </summary>
		public ReadOnlyCollection<StatsStruct> Countries
		{ get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		internal static StatsPeriod FromJson(VkResponse response)
		{
			var statsPeriod = new StatsPeriod
			{
				Day = DateTime.Parse(response["day"], DateTimeFormatInfo.InvariantInfo),
				Views = response["views"],
				Visitors = response["visitors"],
				Reach = response["reach"],
				ReachSubscribers = response["reach_subscribers"],
				Subscribed = response["subscribed"],
				Unsubscribed = response["unsubscribed"],
				Sex = response["sex"].ToReadOnlyCollectionOf<StatsStruct>(x => x),
				Age = response["age"].ToReadOnlyCollectionOf<StatsStruct>(x => x),
				SexAge = response["sex_age"].ToReadOnlyCollectionOf<StatsStruct>(x => x),
				Cities = response["cities"].ToReadOnlyCollectionOf<StatsStruct>(x => x),
				Countries = response["countries"].ToReadOnlyCollectionOf<StatsStruct>(x => x)
			};

			return statsPeriod;
		}
	}
}