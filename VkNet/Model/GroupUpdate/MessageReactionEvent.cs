using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary> Объект, который содержит событие реакции на сообщение. </summary>
[Serializable]
public class MessageReactionEvent : IGroupUpdate
{
	/// <summary>Идентификатор события реакции.</summary>
	[JsonProperty("reacted_id")]
	public long ReactedId { get; set; }

	/// <summary>Идентификатор назначения.</summary>
	[JsonProperty("peer_id")]
	public long PeerId { get; set; }

	/// <summary>Идентификатор сообщения в беседе.</summary>
	[JsonProperty("cmid")]
	public ulong Cmid { get; set; }

	/// <summary>Идентификатор реакции.</summary>
	[JsonProperty("reaction_id")]
	public ulong? ReactionId { get; set; }
}