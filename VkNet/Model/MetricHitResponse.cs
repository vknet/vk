using System;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Событие метрики.
	/// </summary>
	[Serializable]
	public class MetricHitResponse
	{
		/// <summary>
		/// Redirect link
		/// </summary>
		[JsonProperty(propertyName: "redirect_link")]
		public string RedirectLink { get; set; }

		/// <summary>
		/// Information whether request has been processed successfully
		/// </summary>
		[JsonProperty(propertyName: "result")]
		public bool? Result { get; set; }
	}
}