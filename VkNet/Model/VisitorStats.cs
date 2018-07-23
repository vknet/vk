using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Статистика посещений
	/// </summary>
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
}