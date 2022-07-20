using System;
using Newtonsoft.Json;
using VkNet.Model.Keyboard;

namespace VkNet.Model
{
	/// <summary>
	/// Беседа
	/// </summary>
	[Serializable]
	public class Conversation
	{
		/// <summary>
		/// Информация о собеседнике.
		/// </summary>
		[JsonProperty("peer")]
		public Peer Peer { get; set; }

		/// <summary>
		/// Идентификатор последнего прочтенного входящего сообщения.
		/// </summary>
		[JsonProperty("in_read")]
		public long InRead { get; set; }

		/// <summary>
		/// Идентификатор последнего прочтенного исходящего сообщения.
		/// </summary>
		[JsonProperty("out_read")]
		public long OutRead { get; set; }

		/// <summary>
		/// Число непрочитанных сообщений.
		/// </summary>
		[JsonProperty("unread_count")]
		public long? UnreadCount { get; set; }

		/// <summary>
		/// true, если диалог помечен как важный (только для сообщений сообществ).
		/// </summary>
		[JsonProperty("important")]
		public bool Important { get; set; }

		/// <summary>
		/// true, если диалог помечен как неотвеченный (только для сообщений сообществ).
		/// </summary>
		[JsonProperty("unanswered")]
		public bool Unanswered { get; set; }

		/// <summary>
		/// Настройки Push-уведомлений.
		/// </summary>
		[JsonProperty("push_settings")]
		public ConversationPushSettings PushSettings { get; set; }

		/// <summary>
		/// Информация о том, может ли пользователь писать в диалог.
		/// </summary>
		[JsonProperty("can_write")]
		public ConversationCanWrite CanWrite { get; set; }

		/// <summary>
		/// Информация о том, может ли пользователь получать деньги.
		/// </summary>
		[JsonProperty("can_receive_money")]
		public bool? CanReceiveMoney { get; set; }

		/// <summary>
		/// Информация о том, может ли пользователь отправлять деньги.
		/// </summary>
		[JsonProperty("can_send_money")]
		public bool? CanSendMoney { get; set; }

		/// <summary>
		/// Настройки чата.
		/// </summary>
		[JsonProperty("chat_settings")]
		public ConversationChatSettings ChatSettings { get; set; }

		/// <summary>
		/// Идентификатор последнего сообщения.
		/// </summary>
		[JsonProperty("last_message_id")]
		public long LastMessageId { get; set; }

		/// <summary>
		/// Клавиатура.
		/// </summary>
		[JsonProperty("current_keyboard ")]
		public MessageKeyboard CurrentKeyboard { get; set; }
	}
}