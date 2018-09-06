using System;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Статистика по рекламной акции.
	/// </summary>
	[Serializable]
	public class Lead
	{
		/// <summary>
		/// Amount of spent votes
		/// </summary>
		[JsonProperty(propertyName: "spent")]
		public int? Spent { get; set; }

		/// <summary>
		/// Started offers number
		/// </summary>
		[JsonProperty(propertyName: "started")]
		public int? Started { get; set; }

		/// <summary>
		/// Lead limit
		/// </summary>
		[JsonProperty(propertyName: "limit")]
		public int? Limit { get; set; }

		/// <summary>
		/// Property
		/// </summary>
		[JsonProperty(propertyName: "days")]
		public LeadDays Days { get; set; }

		/// <summary>
		/// Impressions number
		/// </summary>
		[JsonProperty(propertyName: "impressions")]
		public int? Impressions { get; set; }

		/// <summary>
		/// Completed offers number
		/// </summary>
		[JsonProperty(propertyName: "completed")]
		public int? Completed { get; set; }

		/// <summary>
		/// Offer cost
		/// </summary>
		[JsonProperty(propertyName: "cost")]
		public int? Cost { get; set; }
	}
}