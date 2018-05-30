using System;
using Newtonsoft.Json;

namespace VkNet.Model.RequestParams.Leads
{
	[Serializable]
	public class CheckUserParams
	{
		[JsonProperty("lead_id")]
		public ulong LeadId { get; set; }

		[JsonProperty("country")]
		public string Country { get; set; }

		[JsonProperty("test_result")]
		public ulong TestResult { get; set; }

		[JsonProperty("test_mode")]
		public bool TestMode { get; set; }

		[JsonProperty("auto_start")]
		public bool AutoStart { get; set; }

		[JsonProperty("age")]
		public ulong Age { get; set; }
	}
}