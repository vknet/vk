using System;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Элемент расписания
	/// </summary>
	/// <remarks>
	/// Время передается в минутах от 0 часов.
	/// </remarks>
	[Serializable]
	public class TimetableItem
	{
		/// <summary>
		/// Время начала работы
		/// </summary>
		[JsonProperty("open_time")]
		public uint OpenTime { get; set; }

		/// <summary>
		/// Время окончания работы
		/// </summary>
		[JsonProperty("close_time")]
		public uint CloseTime { get; set; }

		/// <summary>
		/// Время начала перерыва
		/// </summary>
		[JsonProperty("break_open_time", NullValueHandling = NullValueHandling.Ignore)]
		public uint? BreakOpenTime { get; set; }

		/// <summary>
		/// Время окончания перерыва
		/// </summary>
		[JsonProperty("break_close_time", NullValueHandling = NullValueHandling.Ignore)]
		public uint? BreakCloseTime { get; set; }
	}
}