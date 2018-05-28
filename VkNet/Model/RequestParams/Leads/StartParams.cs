using System;
using Newtonsoft.Json;

namespace VkNet.Model.RequestParams.Leads
{
	[Serializable]
	public class StartParams
	{
		[JsonProperty("lead_id")]
		public ulong LeadId { get; set; }

		[JsonProperty("secret")]
		public string Secret { get; set; }

		[JsonProperty("uid")]
		public ulong Uid { get; set; }

		[JsonProperty("aid")]
		public ulong Aid { get; set; }

		[JsonProperty("test_mode")]
		public bool TestMode { get; set; }

		[JsonProperty("force")]
		public bool Force { get; set; }
	}
}