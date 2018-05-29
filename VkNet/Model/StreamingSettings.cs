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
		[JsonProperty(propertyName: "monthly_limit")]
		[JsonConverter(converterType: typeof(SafetyEnumJsonConverter))]
		public MonthlyLimit MonthlyLimit { get; set; }
	}
}