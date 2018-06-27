using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
		/// Период начала отсчёта в формате YYYY-MM-DD.
		/// </summary>
		[JsonProperty("period_from")]
		[JsonConverter(converterType: typeof(IsoDateTimeConverter))]
		public DateTime PeriodFrom { get; set; }

		/// <summary>
		/// Период окончания отсчёта в формате YYYY-MM-DD.
		/// </summary>
		[JsonProperty("period_to")]
		[JsonConverter(converterType: typeof(IsoDateTimeConverter))]
		public DateTime PeriodTo { get; set; }

		/// <summary>
		/// Данные о посетителях и просмотрах.
		/// </summary>
		[JsonProperty("visitors")]
		public VisitorStats Visitors { get; set; }

		/// <summary>
		/// Данные об охвате.
		/// </summary>
		[JsonProperty("reach")]
		public ReachStats Reach { get; set; }

		/// <summary>
		/// Activity
		/// </summary>
		[JsonProperty("activity")]
		public Activity Activity { get; set; }
	}

	/// <summary>
	/// Activity
	/// </summary>
	[Serializable]
	public class Activity
	{
		/// <summary>
		/// Количество лайков
		/// </summary>
		[JsonProperty("likes")]
		public long Likes { get; set; }

		/// <summary>
		/// Количество подписчиков
		/// </summary>
		[JsonProperty("subscribed")]
		public long Subscribed { get; set; }

		/// <summary>
		/// Количество неподписавшихся.
		/// </summary>
		[JsonProperty("unsubscribed")]
		public long Unsubscribed { get; set; }
	}

	[Serializable]
	public class VisitorStats
	{
		/// <summary>
		/// Число просмотров.
		/// </summary>
		[JsonProperty("views")]
		public long Views { get; set; }

		/// <summary>
		/// Число посетителей;
		/// </summary>
		[JsonProperty("visitors")]
		public long Visitors { get; set; }

		/// <summary>
		/// Число просмотров с мобильных устройств.
		/// </summary>
		[JsonProperty("mobile_views")]
		public long MobileViews { get; set; }

		/// <summary>
		/// Статистика по полу.
		/// </summary>
		[JsonProperty("sex")]
		public IEnumerable<CountValue> Sex { get; set; }

		/// <summary>
		/// Статистика по возрасту.
		/// </summary>
		[JsonProperty("age")]
		public IEnumerable<CountValue> Age { get; set; }

		/// <summary>
		/// Статистика по полу и возрасту.
		/// </summary>
		[JsonProperty("sex_age")]
		public IEnumerable<CountValue> SexAge { get; set; }

		/// <summary>
		/// Статистика по странам.
		/// </summary>
		[JsonProperty("countries")]
		public IEnumerable<City> Countries { get; set; }

		/// <summary>
		/// Статистика по городам.
		/// </summary>
		[JsonProperty("cities")]
		public IEnumerable<City> Cities { get; set; }
	}

	/// <summary>
	/// Count Value
	/// </summary>
	[Serializable]
	public class CountValue
	{
		/// <summary>
		/// Количество
		/// </summary>
		[JsonProperty("count")]
		public long Count { get; set; }

		/// <summary>
		/// Значение
		/// </summary>
		[JsonProperty("value")]
		public string Value { get; set; }
	}

	/// <summary>
	/// Данные об охвате.
	/// </summary>
	[Serializable]
	public class ReachStats
	{
		/// <summary>
		/// Полный охват;
		/// </summary>
		[JsonProperty("reach")]
		public long Reach { get; set; }

		/// <summary>
		/// Охват подписчиков;
		/// </summary>
		[JsonProperty("reach_subscribers")]
		public long ReachSubscribers { get; set; }

		/// <summary>
		/// Охват с мобильных устройств;
		/// </summary>
		[JsonProperty("mobile_reach")]
		public long MobileReach { get; set; }

		/// <summary>
		/// Статистика по полу.
		/// </summary>
		[JsonProperty("sex")]
		public List<CountValue> Sex { get; set; }

		/// <summary>
		/// Статистика по возрасту.
		/// </summary>
		[JsonProperty("age")]
		public List<CountValue> Age { get; set; }

		/// <summary>
		/// Статистика по полу и возрасту.
		/// </summary>
		[JsonProperty("sex_age")]
		public List<CountValue> SexAge { get; set; }

		/// <summary>
		/// Статистика по странам.
		/// </summary>
		[JsonProperty("countries")]
		public List<City> Countries { get; set; }

		/// <summary>
		/// Статистика по городам.
		/// </summary>
		[JsonProperty("cities")]
		public List<City> Cities { get; set; }
	}
}