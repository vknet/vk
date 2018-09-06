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
		public ulong Id { get; set; }

		/// <summary>
		/// Идентификатор пользователя, который отправил подарок, или 0, если отправитель
		/// скрыт.
		/// </summary>
		public long FromId { get; set; }

		/// <summary>
		/// Текст сообщения, приложенного к подарку.
		/// </summary>
		public string Message { get; set; }

		/// <summary>
		/// Время отправки подарка в формате unixtime.
		/// </summary>
		[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
		public DateTime? Date { get; set; }

		/// <summary>
		/// Подарок.
		/// </summary>
		public Gift Gift { get; set; }

		/// <summary>
		/// Значение приватности подарка (только для текущего пользователя).
		/// </summary>
		public GiftPrivacy Privacy { get; set; }

		/// <summary>
		/// Хеш подарка
		/// </summary>
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
					Id = response[key: "id"]
					, FromId = response[key: "from_id"]
					, Message = response[key: "message"]
					, Date = response[key: "date"]
					, Gift = response[key: "gift"]
					, Privacy = response[key: "privacy"]
					, GiftHash = response[key: "gift_hash"]
			};
		}
	}
}