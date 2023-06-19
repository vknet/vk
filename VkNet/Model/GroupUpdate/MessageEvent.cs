using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Объект, который содержит сообщение и информацию о доступных пользователю функциях.
/// </summary>
[Serializable]
public class MessageEvent : IGroupUpdate
{
	/// <summary>
	/// Идентификатор пользователя.
	/// </summary>
	[JsonProperty("user_id")]
	public long? UserId { get; set; }

	/// <summary>
	/// Идентификатор чата.
	/// </summary>
	[JsonProperty("peer_id")]
	public long? PeerId { get; set; }

	/// <summary>
	/// Идентификатор чата.
	/// </summary>
	[JsonProperty("event_id")]
	public string EventId { get; set; }

	/// <summary>
	/// Идентификатор чата.
	/// </summary>
	[JsonProperty("payload")]
	public string Payload { get; set; }

	/// <summary>
	/// Идентификатор сообщения в чате.
	/// </summary>
	[JsonProperty("conversation_message_id")]
	public long? ConversationMessageId { get; set; }
}