using System;
using Newtonsoft.Json;

namespace VkNet.Model.RequestParams.Leads
{
	[Serializable]
	public class GetUsersParams
	{
		[JsonProperty("offer_id")]
		public ulong OfferId { get; set; }

		[JsonProperty("secret")]
		public string Secret { get; set; }

		[JsonProperty("offset")]
		public ulong Offset { get; set; }

		[JsonProperty("count")]
		public ulong Count { get; set; }

		[JsonProperty("status")]
		public ulong Status { get; set; }

		[JsonProperty("reverse")]
		public bool Reverse { get; set; }
	}
}