using System;
using System.Collections.ObjectModel;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Статистика сообщества или приложения.
	/// </summary>
	[Serializable]
	public class StatsPeriod
	{
		/// <summary>
		/// День в формате YYYY-MM-DD.
		/// </summary>
		[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
		public DateTime Day { get; set; }

		/// <summary>
		/// Количество просмотров.
		/// </summary>
		public long Views { get; set; }

		/// <summary>
		/// Количество уникальных посетителей.
		/// </summary>
		public long Visitors { get; set; }

		/// <summary>
		/// Полный охват.
		/// </summary>
		public long? Reach { get; set; }

		/// <summary>
		/// Охват подписчиков.
		/// </summary>
		public long? ReachSubscribers { get; set; }

		/// <summary>
		/// Число новых подписчиков.
		/// </summary>
		public long? Subscribed { get; set; }

		/// <summary>
		/// Число отписавшихся.
		/// </summary>
		public long? Unsubscribed { get; set; }

		/// <summary>
		/// Список структур, описывающих статистику по полу.
		/// </summary>
		public ReadOnlyCollection<StatsStruct> Sex { get; set; }

		/// <summary>
		/// Список структур, описывающих статистику по возрасту.
		/// </summary>
		public ReadOnlyCollection<StatsStruct> Age { get; set; }

		/// <summary>
		/// Список структур, описывающих статистику по полу и возрасту.
		/// </summary>
		public ReadOnlyCollection<StatsStruct> SexAge { get; set; }

		/// <summary>
		/// Список структур, описывающих статистику по городам.
		/// </summary>
		public ReadOnlyCollection<StatsStruct> Cities { get; set; }

		/// <summary>
		/// Список структур, описывающих статистику по странам.
		/// </summary>
		public ReadOnlyCollection<StatsStruct> Countries { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static StatsPeriod FromJson(VkResponse response)
		{
			var statsPeriod = new StatsPeriod
			{
					Day = DateTime.Parse(s: response[key: "day"], provider: DateTimeFormatInfo.InvariantInfo)
					, Views = response[key: "views"]
					, Visitors = response[key: "visitors"]
					, Reach = response[key: "reach"]
					, ReachSubscribers = response[key: "reach_subscribers"]
					, Subscribed = response[key: "subscribed"]
					, Unsubscribed = response[key: "unsubscribed"]
					, Sex = response[key: "sex"].ToReadOnlyCollectionOf<StatsStruct>(selector: x => x)
					, Age = response[key: "age"].ToReadOnlyCollectionOf<StatsStruct>(selector: x => x)
					, SexAge = response[key: "sex_age"].ToReadOnlyCollectionOf<StatsStruct>(selector: x => x)
					, Cities = response[key: "cities"].ToReadOnlyCollectionOf<StatsStruct>(selector: x => x)
					, Countries = response[key: "countries"].ToReadOnlyCollectionOf<StatsStruct>(selector: x => x)
			};

			return statsPeriod;
		}
	}
}