using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VkNet.Model
{
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