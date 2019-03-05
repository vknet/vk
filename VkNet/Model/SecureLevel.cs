using System;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// API Level object.
	/// </summary>
	[Serializable]
	public class SecureLevel
	{
		/// <summary>
		/// Level
		/// </summary>
		[JsonProperty("level")]
		public int? LevelCode { get; set; }

		/// <summary>
		/// User ID
		/// </summary>
		[JsonProperty("uid")]
		public ulong? Uid { get; set; }
	}
}