using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Model.Attachments;
using VkNet.Model.Keyboard;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model
{
	/// <summary>
	/// Объект содержит информацию о закреплённом сообщении в беседе.
	/// </summary>
	[Serializable]
	public class PinnedMessage
	{
		/// <summary>
		/// Идентификатор сообщения.
		/// </summary>
		[JsonProperty("id")]
		public long Id { get; set; }

		/// <summary>
		/// Время отправки сообщения в Unixtime.
		/// </summary>
		[JsonProperty("date")]
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime Date { get; set; }

		/// <summary>
		/// Идентификатор отправителя.
		/// </summary>
		[JsonProperty("from_id")]
		public long FromId { get; set; }

		/// <summary>
		/// Текст сообщения.
		/// </summary>
		[JsonProperty("title")]
		public string Title { get; set; }

		/// <summary>
		/// Медиавложения сообщения (фотографии, ссылки и т.п.).
		/// </summary>
		[JsonProperty("attachments")]
		[JsonConverter(typeof(AttachmentJsonConverter))]
		public ReadOnlyCollection<Attachment> Attachments { get; set; }

		/// <summary>
		/// Информация о местоположении
		/// </summary>
		[JsonProperty("geo")]
		public Geo Geo { get; set; }

		/// <summary>
		/// Массив пересланных сообщений (если есть).
		/// </summary>
		[JsonProperty("fwd_messages")]
		public ReadOnlyCollection<Message> ForwardMessages { get; set; }

		/// <summary>
		/// Идентификатор сообщения.
		/// </summary>
		[JsonProperty("conversation_message_id")]
		public long ConversationMessageId { get; set; }

		/// <summary>
		/// Текст сообщения.
		/// </summary>
		[JsonProperty("text")]
		public string Text { get; set; }

		/// <summary>
		/// Клавиатура.
		/// </summary>
		[JsonProperty("keyboard")]
		public MessageKeyboard Keyboard { get; set; }
	}
}