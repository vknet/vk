using System;
using Newtonsoft.Json;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model
{
	/// <summary>
	/// API LinkStatus object.
	/// </summary>
	[Serializable]
	public class LinkStatus
	{
		/// <summary>
		/// URL
		/// </summary>
		[JsonProperty("redirect_url")]
		public string RedirectUrl { get; set; }

		/// <summary>
		/// Link status
		/// </summary>
		[JsonProperty("status")]
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public LinkStatusType Status { get; set; }

		/// <summary>
		/// Reject reason
		/// </summary>
		[JsonProperty("description")]
		public string Description { get; set; }
	}
}