using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace VkNet.Model
{
	/// <summary>
	/// Результат проверки токена.
	/// </summary>
	[Serializable]
	public class CheckTokenResult
	{
		/// <summary>
		///
		/// </summary>
		[JsonProperty("success")]
		public bool Success { get; set; }

		/// <summary>
		/// Идентификатор пользователя.
		/// </summary>
		[JsonProperty("user_id")]
		public ulong UserId { get; set; }

		/// <summary>
		/// Дата.
		/// </summary>
		[JsonProperty("date")]
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime Date { get; set; }

		/// <summary>
		/// Дата истечения токена.
		/// </summary>
		[JsonProperty("expire")]
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime Expire { get; set; }
	}
}