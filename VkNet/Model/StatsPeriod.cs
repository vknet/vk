using System;
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
}