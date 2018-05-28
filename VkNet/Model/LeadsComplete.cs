using System;
using Newtonsoft.Json;

namespace VkNet.Model
{
	[Serializable]
	public class LeadsComplete
	{
		[JsonProperty("limit")]
		public long Limit { get; set; }

		[JsonProperty("day_limit")]
		public long DayLimit { get; set; }

		[JsonProperty("spent")]
		public long Spent { get; set; }

		[JsonProperty("cost")]
		public string Cost { get; set; }

		[JsonProperty("test_mode")]
		public long TestMode { get; set; }

		[JsonProperty("success")]
		public long Success { get; set; }
	}
}