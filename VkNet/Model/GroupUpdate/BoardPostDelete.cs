using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Удаление комментария в обсуждении (<c>BoardPostDelete</c>)
/// </summary>
[Serializable]
public class BoardPostDelete : IGroupUpdate
{
	/// <summary>
	/// Идентификатор комментария
	/// </summary>
	[JsonProperty("id")]
	public ulong? Id { get; set; }

	/// <summary>
	/// Идентификатор обсуждения
	/// </summary>
	[JsonProperty("topic_id")]
	public ulong? TopicId { get; set; }

	/// <summary>
	/// Идентификатор владельца обсуждения
	/// </summary>
	[JsonProperty("topic_owner_id")]
	public long? TopicOwnerId { get; set; }
}