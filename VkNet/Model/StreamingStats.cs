using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model
{
	/// <summary>
	/// Streaming Stats
	/// </summary>
	[Serializable]
	public class StreamingStats
	{
		/// <summary>
		/// Тип событий
		/// </summary>
		[JsonProperty(propertyName: "event_type")]
		[JsonConverter(converterType: typeof(SafetyEnumJsonConverter))]
		public StreamingEventType EventType { get; set; }

		/// <summary>
		/// Значения статистики
		/// </summary>
		[JsonProperty(propertyName: "stats")]
		public ReadOnlyCollection<StreamingStatsItem> Stats { get; set; }
	}
}