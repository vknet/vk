using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace VkNet.Model
{
	/// <summary>
	/// API Notification object.
	/// </summary>
	[Serializable]
	public class Notification
	{
		/// <summary>
		/// Тип оповещения.
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; }

		/// <summary>
		/// Время появления ответа в формате Unixtime.
		/// </summary>
		[JsonProperty("date")]
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime Date { get; set; }

		/// <summary>
		/// Объект описывающий поступивший ответ. 
		/// </summary>
		[JsonProperty("feedback")]
		public Feedback Feedback { get; set; }

		/// <summary>
		/// объект, описывающий комментарий текущего пользователя, отправленный в ответ на данное оповещение. Отсутствует, если пользователь ещё не давал ответа.
		/// </summary>
		[JsonProperty("reply")]
		public Reply Reply { get; set; }
		
		/// <summary>
		/// Property
		/// </summary>
		[JsonProperty("parent")]
		public Feedback Parent { get; set; }
	}
}