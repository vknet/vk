using System;
using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model;

/// <summary>
/// результат выполнения запроса messages.send
/// </summary>
[Serializable]
[JsonConverter(typeof(MessagesSendResultJsonConverter))]
public class MessagesSendResult
{
	/// <summary>
	/// Идентификатор назначения;
	/// </summary>
	[JsonProperty("peer_id")]
	public long? PeerId { get; set; }

	/// <summary>
	/// Идентификатор сообщения
	/// </summary>
	[JsonProperty("message_id")]
	public long? MessageId { get; set; }

	/// <summary>
	/// Идентификатор сообщения в диалоге
	/// </summary>
	[JsonProperty("conversation_message_id")]
	public long? ConversationMessageId { get; set; }

	/// <summary>
	/// Код ошибки если есть (в наличии в версии 5.101)
	/// </summary>
	[JsonProperty("error_code")]
	public int ErrorCode { get; set; }

	/// <summary>
	/// Cообщение об ошибке, если сообщение не было доставлено получателю.
	/// </summary>
	[JsonProperty("error")]
	public string Error { get; set; }
}