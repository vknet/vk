using System;
using Newtonsoft.Json;

namespace VkNet.Model
{
	[Serializable]
	public class MetricHitResponse
	{
		/// <summary>
		/// Redirect link
		/// </summary>
		[JsonProperty("redirect_link")]
		public string RedirectLink { get; set; }

		/// <summary>
		/// Information whether request has been processed successfully
		/// </summary>
		[JsonProperty("result")]
		public bool? Result { get; set; }
	}
}