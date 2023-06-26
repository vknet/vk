using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Добавление/редактирование/восстановление комментария в обсуждении(<c>BoardPostNew</c>, <c>BoardPostEdit</c>, <c>BoardPostRestore</c>)
/// (<c>CommentBoard</c> с дополнительными полями)
/// </summary>
[Serializable]
public class BoardPost : CommentBoard, IGroupUpdate
{
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