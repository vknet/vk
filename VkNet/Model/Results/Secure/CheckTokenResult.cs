using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace VkNet.Model
{
	[Serializable]
	public class CheckTokenResult
	{
		[JsonProperty("success")]
		public bool Success { get; set; }

		[JsonProperty("user_id")]
		public ulong UserId { get; set; }

		[JsonProperty("date")]
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime Date { get; set; }

		[JsonProperty("expire")]
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime Expire { get; set; }
	}
}