using System;
using Newtonsoft.Json;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model
{
	/// <summary>
	/// Модель обьекта статистики истории.
	/// </summary>
	[Serializable]
	public class StoryStatsObject
	{
		/// <summary>
		/// Доступность значения.
		/// </summary>
		[JsonProperty("state")]
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public StoryObjectState State { get; set; }

		/// <summary>
		/// Значение счётчика.
		/// </summary>
		[JsonProperty("count", NullValueHandling = NullValueHandling.Ignore)]
		public int? Count { get; set; }
	}
}