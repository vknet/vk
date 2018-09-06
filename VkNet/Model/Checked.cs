using System;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Доступность рекламной акции пользователю.
	/// </summary>
	[Serializable]
	public class Checked
	{
		/// <summary>
		/// Information whether user can start the lead
		/// </summary>
		[JsonProperty(propertyName: "result")]
		public string Result { get; set; }

		/// <summary>
		/// URL user should open to start the lead
		/// </summary>
		[JsonProperty(propertyName: "start_link")]
		public string StartLink { get; set; }

		/// <summary>
		/// Session ID
		/// </summary>
		[JsonProperty(propertyName: "sid")]
		public string Sid { get; set; }

		/// <summary>
		/// Reason why user can't start the lead
		/// </summary>
		[JsonProperty(propertyName: "reason")]
		public string Reason { get; set; }
	}
}