using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace VkNet.Model
{
	/// <summary>
	/// Элемент истории смс
	/// </summary>
	[Serializable]
	public class SmsHistoryItem
	{
		/// <summary>
		/// Идентификатор
		/// </summary>
		[JsonProperty("id")]
		public long Id { get; set; }

		/// <summary>
		/// Идентификатор приложения
		/// </summary>
		[JsonProperty("app_id")]
		public long AppId { get; set; }

		/// <summary>
		/// Идентификатор пользователя
		/// </summary>
		[JsonProperty("user_id")]
		public long UserId { get; set; }

		/// <summary>
		/// Дата
		/// </summary>
		[JsonProperty("date")]
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime Date { get; set; }

		/// <summary>
		/// Сообщение
		/// </summary>
		[JsonProperty("message")]
		public string Message { get; set; }
	}
}