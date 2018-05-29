using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace VkNet.Model
{
	/// <summary>
	/// Последние действия пользователей по рекламной акции
	/// </summary>
	[Serializable]
	public class Entry
	{
		/// <summary>
		/// Время действия в формате unixtime;
		/// </summary>
		[JsonProperty("date")]
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime? Date { get; set; }

		/// <summary>
		///  0 - начало действия, 1 - завершение действия, 2 - блокирование пользователя;
		/// </summary>
		[JsonProperty("status")]
		public int? Status { get; set; }

		/// <summary>
		/// Идентификатор пользователя;
		/// </summary>
		[JsonProperty("uid")]
		public int? Uid { get; set; }

		/// <summary>
		/// Текст комментария.
		/// </summary>
		[JsonProperty("comment")]
		public string Comment { get; set; }

		/// <summary>
		/// Идентификатор приложения, из которого было выполнено действие;
		/// </summary>
		[JsonProperty("aid")]
		public int? Aid { get; set; }

		/// <summary>
		/// 0 - рабочий режим, 1 - тестовый режим;
		/// </summary>
		[JsonProperty("test_mode")]
		public int? TestMode { get; set; }

		/// <summary>
		/// Время начала действия в формате unixtime для status = 1;
		/// </summary>
		[JsonProperty("start_date")]
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime? StartDate { get; set; }

		/// <summary>
		/// Идентификатор сессии;
		/// </summary>
		[JsonProperty("sid")]
		public string Sid { get; set; }
	}
}