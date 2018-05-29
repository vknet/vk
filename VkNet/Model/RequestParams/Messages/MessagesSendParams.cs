using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using VkNet.Model.Attachments;
using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры метода messages.send
	/// </summary>
	[Serializable]
	public class MessagesSendParams
	{
		/// <summary>
		/// Идентификатор пользователя, которому отправляется сообщение.
		/// </summary>
		[JsonProperty(propertyName: "user_id")]
		public long? UserId { get; set; }

		/// <summary>
		/// Уникальный идентификатор, предназначенный для предотвращения повторной отправки
		/// одинакового сообщения.
		/// Сохраняется вместе с сообщением и доступен в истории сообщений.
		/// </summary>
		[JsonProperty(propertyName: "random_id")]
		public long? RandomId { get; set; }

		/// <summary>
		/// Идентификатор назначения. Для групповой беседы: 2000000000 + id беседы. Для
		/// сообщества: -id сообщества.
		/// </summary>
		[JsonProperty(propertyName: "peer_id")]
		public long? PeerId { get; set; }

		/// <summary>
		/// Короткий адрес пользователя (например, illarionov).
		/// </summary>
		[JsonProperty(propertyName: "domain")]
		public string Domain { get; set; }

		/// <summary>
		/// Идентификатор беседы, к которой будет относиться сообщение.
		/// </summary>
		[JsonProperty(propertyName: "chat_id")]
		public long? ChatId { get; set; }

		/// <summary>
		/// Идентификаторы получателей сообщения (при необходимости отправить сообщение
		/// сразу нескольким пользователям).
		/// </summary>
		[JsonProperty(propertyName: "user_ids")]
		public IEnumerable<long> UserIds { get; set; }

		/// <summary>
		/// Текст личного сообщения (является обязательным, если не задан параметр
		/// attachment)
		/// </summary>
		[JsonProperty(propertyName: "message")]
		public string Message { get; set; }

		/// <summary>
		/// Latitude - широта при добавлении местоположения.
		/// </summary>
		[JsonProperty(propertyName: "lat")]
		public double? Lat { get; set; }

		/// <summary>
		/// Longitude - долгота при добавлении местоположения.
		/// </summary>
		[JsonProperty(propertyName: "long")]
		public double? Longitude { get; set; }

		/// <summary>
		/// Медиавложения к личному сообщению, перечисленные через запятую.
		/// </summary>
		[JsonProperty(propertyName: "attachment")]
		public IEnumerable<MediaAttachment> Attachments { get; set; }

		/// <summary>
		/// Идентификаторы пересылаемых сообщений, перечисленные через запятую.
		/// Перечисленные сообщения отправителя будут
		/// отображаться в теле письма у получателя.
		/// </summary>
		[JsonProperty(propertyName: "forward_messages")]
		public IEnumerable<long> ForwardMessages { get; set; }

		/// <summary>
		/// Идентификатор стикера.
		/// </summary>
		[JsonProperty(propertyName: "sticker_id")]
		public uint? StickerId { get; set; }

		/// <summary>
		/// Идентификатор капчи
		/// </summary>
		[JsonProperty(propertyName: "captcha_sid")]
		public long? CaptchaSid { get; set; }

		/// <summary>
		/// текст, который ввел пользователь
		/// </summary>
		[JsonProperty(propertyName: "captcha_key")]
		public string CaptchaKey { get; set; }

		/// <summary>
		/// Привести к типу VkParameters.
		/// </summary>
		/// <param name="p"> Параметры. </param>
		/// <returns> </returns>
		public static VkParameters ToVkParameters(MessagesSendParams p)
		{
			return new VkParameters
			{
					{ "user_id", p.UserId }
					, { "domain", p.Domain }
					, { "chat_id", p.ChatId }
					, { "user_ids", p.UserIds }
					, { "message", p.Message }
					, { "random_id", p.RandomId }
					, { "lat", p.Lat }
					, { "long", p.Longitude }
					, { "attachment", p.Attachments }
					, { "forward_messages", p.ForwardMessages }
					, { "sticker_id", p.StickerId }
					, { "captcha_sid", p.CaptchaSid }
					, { "captcha_key", p.CaptchaKey }
					, { "peer_id", p.PeerId }
			};
		}
	}
}