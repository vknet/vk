using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace VkNet.Model
{
	[Serializable]
	public class SmsHistoryItem
	{
		[JsonProperty("id")]
		public long Id { get; set; }

		[JsonProperty("app_id")]
		public long AppId { get; set; }

		[JsonProperty("user_id")]
		public long UserId { get; set; }

		[JsonProperty("date")]
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime Date { get; set; }

		[JsonProperty("message")]
		public string Message { get; set; }
	}
}