using System;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Беседы
	/// </summary>
	[Serializable]
	public class ConversationAndLastMessage
	{
		/// <summary>
		/// Объект беседы
		/// </summary>
		[JsonProperty("conversation")]
		public Conversation Conversation { get; set; }

		/// <summary>
		/// Объект, описывающий последнее сообщение в беседе.
		/// </summary>
		[JsonProperty("last_message")]
		public Message LastMessage { get; set; }
	}
}