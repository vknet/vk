using System.Collections.Generic;
using System.Net;
using VkNet.Model.Attachments;

namespace VkNet.Model.RequestParams
{
	using Utils;

	/// <summary>
	/// Параметры метода messages.send
	/// </summary>
	public struct MessagesSendParams
	{
		/// <summary>
		/// Идентификатор пользователя, которому отправляется сообщение.
		/// </summary>
		public long? UserId
		{ get; set; }

		/// <summary>
		/// Короткий адрес пользователя (например, illarionov).
		/// </summary>
		public string Domain
		{ get; set; }

		/// <summary>
		/// Идентификатор беседы, к которой будет относиться сообщение.
		/// </summary>
		public long? ChatId
		{ get; set; }

		/// <summary>
		/// Идентификаторы получателей сообщения (при необходимости отправить сообщение сразу нескольким пользователям).
		/// </summary>
		public IEnumerable<long> UserIds
		{ get; set; }

		/// <summary>
		/// Текст личного сообщения (является обязательным, если не задан параметр attachment)
		/// </summary>
		public string Message
		{ get; set; }

		/// <summary>
		/// Уникальный идентификатор, предназначенный для предотвращения повторной отправки одинакового сообщения.
		/// Сохраняется вместе с сообщением и доступен в истории сообщений.
		/// </summary>
		public long? RandomId
		{ get; set; }

		/// <summary>
		/// Latitude - широта при добавлении местоположения.
		/// </summary>
		public double? Lat
		{ get; set; }

		/// <summary>
		/// Longitude - долгота при добавлении местоположения.
		/// </summary>
		public double? Longitude
		{ get; set; }

		/// <summary>
		/// Медиавложения к личному сообщению, перечисленные через запятую.
		/// </summary>
		public IEnumerable<MediaAttachment> Attachments
		{ get; set; }

		/// <summary>
		/// Идентификаторы пересылаемых сообщений, перечисленные через запятую. Перечисленные сообщения отправителя будут отображаться в теле письма у получателя.
		/// </summary>
		public IEnumerable<long> ForwardMessages
		{ get; set; }

		/// <summary>
		/// Идентификатор стикера.
		/// </summary>
		public uint? StickerId
		{ get; set; }

		/// <summary>
		/// Идентификатор капчи
		/// </summary>
		public long? CaptchaSid { get; set; }

		/// <summary>
		/// текст, который ввел пользователь
		/// </summary>
		public string CaptchaKey { get; set; }

		/// <summary>
		/// Идентификатор назначения. Для групповой беседы: 2000000000 + id беседы. Для сообщества: -id сообщества.
		/// </summary>
		public long? PeerId { get; set; }

		/// <summary>
		/// Привести к типу VkParameters.
		/// </summary>
		/// <param name="p">Параметры.</param>
		/// <returns></returns>
		internal static VkParameters ToVkParameters(MessagesSendParams p)
		{
			return new VkParameters
			{
				{ "user_id", p.UserId },
				{ "domain", p.Domain },
				{ "chat_id", p.ChatId },
				{ "user_ids", p.UserIds },
				{ "message", WebUtility.UrlEncode(p.Message) },
				{ "random_id", p.RandomId },
				{ "lat", p.Lat },
				{ "long", p.Longitude },
				{ "attachment", p.Attachments },
				{ "forward_messages", p.ForwardMessages },
				{ "sticker_id", p.StickerId },
				{ "captcha_sid", p.CaptchaSid },
				{ "captcha_key", p.CaptchaKey },
				{ "peer_id", p.PeerId }
			};
		}
	}
}
