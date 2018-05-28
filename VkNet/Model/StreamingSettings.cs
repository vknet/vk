using System;
using Newtonsoft.Json;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model
{
	/// <summary>
	/// Streaming Settings.
	/// </summary>
	[Serializable]
	public class StreamingSettings
	{
		/// <summary>
		/// Месячные ограничения
		/// </summary>
		[JsonProperty("monthly_limit")]
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public MonthlyLimit MonthlyLimit { get; set; }
	}
}