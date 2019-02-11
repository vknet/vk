using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace VkNet.Model
{
	/// <summary>
	/// API Transaction object.
	/// </summary>
	[Serializable]
	public class Transaction
	{
		/// <summary>
		/// From ID
		/// </summary>
		[JsonProperty("uid_from")]
		public ulong? UidFrom { get; set; }

		/// <summary>
		/// Transaction date in Unixtime
		/// </summary>
		[JsonProperty("date")]
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime? Date { get; set; }

		/// <summary>
		/// Votes number
		/// </summary>
		[JsonProperty("votes")]
		public int? Votes { get; set; }

		/// <summary>
		/// Transaction ID
		/// </summary>
		[JsonProperty("id")]
		public ulong? Id { get; set; }

		/// <summary>
		/// To ID
		/// </summary>
		[JsonProperty("uid_to")]
		public ulong? UidTo { get; set; }
	}
}