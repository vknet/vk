using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VkNet.Utils;

namespace VkNet.Model
{
	[Serializable]
    public class VotesAmount
    {
		[JsonProperty(propertyName: "votes")]
		public string Votes { get; set; }

		[JsonProperty(propertyName: "amount")]
		public int Amount { get; set; }

		[JsonProperty(propertyName: "description")]
		public string Description { get; set; }

		[JsonProperty(propertyName: "currency")]
		public string Currency { get; set; }
	}
}
