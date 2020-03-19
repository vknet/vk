using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.Attachments;
using VkNet.Model.Keyboard;
using VkNet.Model.Template;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры метода messages.send
	/// </summary>
	[Serializable]
	public class MessagesSendParams
	{
		/// <summary>
		/// Короткий адрес пользователя (например, illarionov).
		/// </summary>
		[JsonProperty("domain")]
		public string Domain { get; set; }

		/// <summary>
		/// Текст личного сообщения (является обязательным, если не задан параметр
		/// attachment)
		/// </summary>
		[JsonProperty("message")]
		public string Message { get; set; }

		/// <summary>
		/// Медиавложения к личному сообщению, перечисленные через запятую.
		/// </summary>
		[JsonProperty("attachment")]
		public IEnumerable<MediaAttachment> Attachments { get; set; }

		/// <summary>
		/// Идентификаторы пересылаемых сообщений, перечисленные через запятую.
		/// Перечисленные сообщения отправителя будут
		/// отображаться в теле письма у получателя.
		/// </summary>
		[JsonProperty("forward_messages")]
		public IEnumerable<long> ForwardMessages { get; set; }

		/// <summary>
		/// Объект, описывающий клавиатуру для бота.
		/// </summary>
		/// <remarks>
		/// Рекомендуется для построения использовать <see cref="IKeyboardBuilder" />
		/// </remarks>
		[JsonProperty("keyboard")]
		public MessageKeyboard Keyboard { get; set; }

		/// <summary>
		/// Идентификатор пользователя, которому отправляется сообщение.
		/// </summary>
		[JsonProperty("user_id")]
		public long? UserId { get; set; }

		/// <summary>
		/// Уникальный идентификатор, предназначенный для предотвращения повторной отправки
		/// одинакового сообщения.
		/// Сохраняется вместе с сообщением и доступен в истории сообщений.
		/// </summary>
		[JsonProperty("random_id")]
		public int? RandomId { get; set; }

		/// <summary>
		/// Идентификатор назначения. Для групповой беседы: 2000000000 + id беседы. Для
		/// сообщества: -id сообщества.
		/// </summary>
		[JsonProperty("peer_id")]
		public long? PeerId { get; set; }

		/// <summary>
		/// Идентификатор беседы, к которой будет относиться сообщение.
		/// </summary>
		[JsonProperty("chat_id")]
		public long? ChatId { get; set; }

		/// <summary>
		/// Идентификаторы получателей сообщения (при необходимости отправить сообщение
		/// сразу нескольким пользователям).
		/// </summary>
		[JsonProperty("user_ids")]
		public IEnumerable<long> UserIds { get; set; }

		/// <summary>
		/// Latitude - широта при добавлении местоположения.
		/// </summary>
		[JsonProperty("lat")]
		public double? Lat { get; set; }

		/// <summary>
		/// Longitude - долгота при добавлении местоположения.
		/// </summary>
		[JsonProperty("long")]
		public double? Longitude { get; set; }

		/// <summary>
		/// Идентификатор стикера.
		/// </summary>
		[JsonProperty("sticker_id")]
		public uint? StickerId { get; set; }

		/// <summary>
		/// Идентификатор сообщества (для сообщений сообщества с ключом доступа
		/// пользователя). положительное число
		/// </summary>
		[JsonProperty("group_id")]
		public ulong GroupId { get; set; }

		/// <summary>
		/// Полезная нагрузка (максимальная длина 1000)
		/// </summary>
		[JsonProperty("payload")]
		public string Payload { get; set; }

		/// <summary>
		/// 1 — не создавать сниппет ссылки из сообщения флаг, может принимать значения 1
		/// или 0, по умолчанию
		/// </summary>
		[JsonProperty("dont_parse_links")]
		public bool DontParseLinks { get; set; }

		/// <summary>
		/// Идентификатор капчи
		/// </summary>
		[JsonProperty("captcha_sid")]
		[Obsolete(ObsoleteText.CaptchaNeeded, true)]
		public long? CaptchaSid { get; set; }

		/// <summary>
		/// текст, который ввел пользователь
		/// </summary>
		[JsonProperty("captcha_key")]
		[Obsolete(ObsoleteText.CaptchaNeeded, true)]
		public string CaptchaKey { get; set; }

		/// <summary>
		/// 1 - отключить уведомление об упоминании в сообщении, может принимать значения 1
		/// или 0, по умолчанию
		/// </summary>
		[JsonProperty("disable_mentions")]
		public bool DisableMentions { get; set; }

		/// <summary>
		/// Метка, которая обозначает приблизительное содержание сообщения от сообщества
		/// </summary>
		[JsonProperty("intent")]
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public Intent Intent { get; set; }

		/// <summary>
		/// Объект, описывающий шаблон сообщения для бота.
		/// </summary>
		/// <remarks>
		/// Рекомендуется для построения использовать <see cref="ITemplateBuilder" />
		/// </remarks>
		[JsonProperty("template")]
		public MessageTemplate Template { get; set; }
	}
}