using System;
using System.Collections.ObjectModel;
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
		public DateTime day
		{ get; set; }

		/// <summary>
		/// Количество просмотров.
		/// </summary>
		public long views
		{ get; set; }

		/// <summary>
		/// Количество уникальных посетителей.
		/// </summary>
		public long visitors
		{ get; set; }

		/// <summary>
		/// Полный охват.
		/// </summary>
		public long? reach
		{ get; set; }

		/// <summary>
		/// Охват подписчиков.
		/// </summary>
		public long? reach_subscribers
		{ get; set; }

		/// <summary>
		/// Число новых подписчиков.
		/// </summary>
		public long subscribed
		{ get; set; }

		/// <summary>
		/// Число отписавшихся.
		/// </summary>
		public long unsubscribed
		{ get; set; }

		/// <summary>
		/// Список структур, описывающих статистику по полу.
		/// </summary>
		public ReadOnlyCollection<StatsStruct> sex
		{ get; set; }

		/// <summary>
		/// Список структур, описывающих статистику по возрасту.
		/// </summary>
		public ReadOnlyCollection<StatsStruct> age
		{ get; set; }

		/// <summary>
		/// Список структур, описывающих статистику по полу и возрасту.
		/// </summary>
		public ReadOnlyCollection<StatsStruct> sex_age
		{ get; set; }

		/// <summary>
		/// Список структур, описывающих статистику по городам.
		/// </summary>
		public ReadOnlyCollection<StatsStruct> cities
		{ get; set; }

		/// <summary>
		/// Список структур, описывающих статистику по странам.
		/// </summary>
		public ReadOnlyCollection<StatsStruct> countries
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
				day = DateTime.Parse(response["day"]),
				views = response["views"],
				visitors = response["visitors"],
				reach = response["reach"],
				reach_subscribers = response["reach_subscribers"],
				subscribed = response["subscribed"],
				unsubscribed = response["unsubscribed"],
				sex = response["sex"].ToReadOnlyCollectionOf<StatsStruct>(x => x),
				age = response["age"].ToReadOnlyCollectionOf<StatsStruct>(x => x),
				sex_age = response["sex_age"].ToReadOnlyCollectionOf<StatsStruct>(x => x),
				cities = response["cities"].ToReadOnlyCollectionOf<StatsStruct>(x => x),
				countries = response["countries"].ToReadOnlyCollectionOf<StatsStruct>(x => x)
			};

			return statsPeriod;
		}
	}
}