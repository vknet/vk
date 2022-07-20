using System;
using Newtonsoft.Json;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model
{
	/// <summary>
	/// Объект, описывающий источник пользовательского контента для чат-ботов.
	/// Если источником является другое сообщение(например, сообщение от пользователя боту)
	/// </summary>
	[Serializable]
	public class MessageContentSource
	{
		/// <summary>
		/// Источник.
		/// </summary>
		[JsonProperty("type")]
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public MessageContentSourceType Type { get; set; }

		/// <summary>
		/// От чьего имени указан peer_id. т.е. вы можете использовать контент из сообщения другой группы.
		/// </summary>
		[JsonProperty("owner_id", NullValueHandling = NullValueHandling.Ignore)]
		public long? OwnerId { get; set; }

		/// <summary>
		/// Id диалога
		/// </summary>
		[JsonProperty("peer_id", NullValueHandling = NullValueHandling.Ignore)]
		public long? PeerId { get; set; }

		/// <summary>
		/// Id сообщения в беседе. Не путать с message.id профиля.
		/// </summary>
		[JsonProperty("conversation_message_id", NullValueHandling = NullValueHandling.Ignore)]
		public long? ConversationMessageId { get; set; }

		/// <summary>
		/// Если источником является любой другой контент на платформе (комментарий, пост, фотография и тд.).
		/// </summary>
		[JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
		public string Url { get; set; }
	}
}