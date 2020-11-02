#nullable enable
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Параметр отвечает за пересылку сообщений в другие чаты и ответ на сообщение в рамках одной беседы.
	/// </summary>
	[Serializable]
	public class MessageForward
	{
		/// <summary>
		/// Владелец сообщений. Стоит передавать, если вы хотите переслать сообщения из сообщества в диалог.
		/// </summary>
		[JsonProperty("owner_id", NullValueHandling = NullValueHandling.Ignore)]
		public long? OwnerId { get; set; }

		/// <summary>
		/// Идентификатор места, из которого необходимо переслать сообщения.
		/// </summary>
		[JsonProperty("peer_id", NullValueHandling = NullValueHandling.Ignore)]
		public long? PeerId { get; set; }

		/// <summary>
		/// Массив conversation_message_id сообщений, которые необходимо переслать.
		/// В массив conversation_message_ids можно передать сообщения:
		/// находящиеся в личном диалоге с ботом;
		///	являющиеся исходящими сообщениями бота;
		/// написанными после того, как бот вступил в беседу и появился доступ к сообщениям.
		/// </summary>
		[JsonProperty("conversation_message_ids", NullValueHandling = NullValueHandling.Ignore)]
		public IEnumerable<long>? ConversationMessageIds { get; set; }

		/// <summary>
		/// Массив id сообщений.
		/// </summary>
		[JsonProperty("message_ids", NullValueHandling = NullValueHandling.Ignore)]
		public IEnumerable<long>? MessageIds { get; set; }

		/// <summary>
		/// Ответ на сообщения.
		/// Стоит передавать, если вы хотите ответить на сообщения в том чате, в котором находятся сообщения.
		/// При этом в conversation_message_ids/message_ids должен находиться только один элемент.
		/// </summary>
		[JsonProperty("is_reply", NullValueHandling = NullValueHandling.Ignore)]
		public bool? IsReply { get; set; }
	}
}