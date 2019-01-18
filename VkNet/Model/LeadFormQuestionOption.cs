using System;
using Newtonsoft.Json;

namespace VkNet.Model
{
	[Serializable]
	public class LeadFormQuestionOption
	{
		[JsonProperty("label")]
		public string Label { get; set; }

		[JsonProperty("key", NullValueHandling = NullValueHandling.Ignore)]
		public string Key { get; set; }
	}
}