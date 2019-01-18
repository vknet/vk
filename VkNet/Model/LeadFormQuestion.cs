using System;
using Newtonsoft.Json;

namespace VkNet.Model
{
	[Serializable]
	public class LeadFormQuestion
	{
		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("key")]
		public string Key { get; set; }

		[JsonProperty("label", NullValueHandling = NullValueHandling.Ignore)]
		public string Label { get; set; }

		[JsonProperty("options", NullValueHandling = NullValueHandling.Ignore)]
		public LeadFormQuestionOption[] Options { get; set; }
	}
}