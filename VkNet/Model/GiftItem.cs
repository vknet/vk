using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Enums;
using VkNet.Model.Attachments;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Подарок.
	/// </summary>
	[Serializable]
	public class GiftItem
	{
		/// <summary>
		/// Идентификатор полученного подарка.
		/// </summary>
		[JsonProperty("id")]
		public long Id { get; set; }

		/// <summary>
		/// Идентификатор пользователя, который отправил подарок, или 0, если отправитель
		/// скрыт.
		/// </summary>
		[JsonProperty("from_id")]
		public long FromId { get; set; }

		/// <summary>
		/// Текст сообщения, приложенного к подарку.
		/// </summary>
		[JsonProperty("message")]
		public string Message { get; set; }

		/// <summary>
		/// Время отправки подарка в формате unixtime.
		/// </summary>
		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("date")]
		public DateTime? Date { get; set; }

		/// <summary>
		/// Подарок.
		/// </summary>
		[JsonProperty("gift")]
		public Gift Gift { get; set; }

		/// <summary>
		/// Значение приватности подарка (только для текущего пользователя).
		/// </summary>
		[JsonProperty("privacy")]
		public GiftPrivacy Privacy { get; set; }

		/// <summary>
		/// Хеш подарка
		/// </summary>
		[JsonProperty("gift_hash")]
		public string GiftHash { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static GiftItem FromJson(VkResponse response)
		{
			return new GiftItem
			{
				Id = response["id"],
				FromId = response["from_id"],
				Message = response["message"],
				Date = response["date"],
				Gift = response["gift"],
				Privacy = response["privacy"],
				GiftHash = response["gift_hash"]
			};
		}
	}
}