using System;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Days
	/// </summary>
	[Serializable]
	public class LeadDays
	{
		/// <summary>
		/// Amount of spent votes
		/// </summary>
		[JsonProperty("spent")]
		public int? Spent { get; set; }

		/// <summary>
		/// Impressions number
		/// </summary>
		[JsonProperty("impressions")]
		public int? Impressions { get; set; }

		/// <summary>
		/// Completed offers number
		/// </summary>
		[JsonProperty("completed")]
		public int? Completed { get; set; }

		/// <summary>
		/// Started offers number
		/// </summary>
		[JsonProperty("started")]
		public int? Started { get; set; }
	}
}