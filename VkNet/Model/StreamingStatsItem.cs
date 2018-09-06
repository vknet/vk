using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace VkNet.Model
{
	/// <summary>
	/// Элемент статистики для стрима
	/// </summary>
	[Serializable]
	public class StreamingStatsItem
	{
		/// <summary>
		/// Время, соответствующее значению;
		/// </summary>
		[JsonProperty(propertyName: "timestamp")]
		[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
		public DateTime Timestamp { get; set; }

		/// <summary>
		/// Значение
		/// </summary>
		[JsonProperty(propertyName: "value")]
		public int Value { get; set; }
	}
}