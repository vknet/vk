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
		[JsonProperty(propertyName: "date")]
		[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
		public DateTime? Date { get; set; }

		/// <summary>
		/// 0 - начало действия, 1 - завершение действия, 2 - блокирование пользователя;
		/// </summary>
		[JsonProperty(propertyName: "status")]
		public int? Status { get; set; }

		/// <summary>
		/// Идентификатор пользователя;
		/// </summary>
		[JsonProperty(propertyName: "uid")]
		public int? Uid { get; set; }

		/// <summary>
		/// Текст комментария.
		/// </summary>
		[JsonProperty(propertyName: "comment")]
		public string Comment { get; set; }

		/// <summary>
		/// Идентификатор приложения, из которого было выполнено действие;
		/// </summary>
		[JsonProperty(propertyName: "aid")]
		public int? Aid { get; set; }

		/// <summary>
		/// 0 - рабочий режим, 1 - тестовый режим;
		/// </summary>
		[JsonProperty(propertyName: "test_mode")]
		public int? TestMode { get; set; }

		/// <summary>
		/// Время начала действия в формате unixtime для status = 1;
		/// </summary>
		[JsonProperty(propertyName: "start_date")]
		[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
		public DateTime? StartDate { get; set; }

		/// <summary>
		/// Идентификатор сессии;
		/// </summary>
		[JsonProperty(propertyName: "sid")]
		public string Sid { get; set; }
	}
}