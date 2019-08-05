using System;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Расписание
	/// </summary>
	[Serializable]
	[JsonObject(MemberSerialization.OptOut)]
	public class Timetable
	{
		/// <summary>
		/// Понедельник
		/// </summary>
		[JsonProperty("mon", NullValueHandling = NullValueHandling.Ignore)]
		public TimetableItem Monday { get; set; }

		/// <summary>
		/// Вторник
		/// </summary>
		[JsonProperty("tue", NullValueHandling = NullValueHandling.Ignore)]
		public TimetableItem Tuesday { get; set; }

		/// <summary>
		/// Среда
		/// </summary>
		[JsonProperty("wed", NullValueHandling = NullValueHandling.Ignore)]
		public TimetableItem Wednesday { get; set; }

		/// <summary>
		/// Четверг
		/// </summary>
		[JsonProperty("thu", NullValueHandling = NullValueHandling.Ignore)]
		public TimetableItem Thursday { get; set; }

		/// <summary>
		/// Пятница
		/// </summary>
		[JsonProperty("fri", NullValueHandling = NullValueHandling.Ignore)]
		public TimetableItem Friday { get; set; }

		/// <summary>
		/// Суббота
		/// </summary>
		[JsonProperty("sat", NullValueHandling = NullValueHandling.Ignore)]
		public TimetableItem Saturday { get; set; }

		/// <summary>
		/// Воскресенье
		/// </summary>
		[JsonProperty("sun", NullValueHandling = NullValueHandling.Ignore)]
		public TimetableItem Sunday { get; set; }
	}
}