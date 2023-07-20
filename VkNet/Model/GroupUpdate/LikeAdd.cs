using System;
using Newtonsoft.Json;
using VkNet.Enums.StringEnums;

namespace VkNet.Model;

/// <summary>
/// Событие о новой отметке "Мне нравится"
/// </summary>
[Serializable]
public class LikeAdd : IGroupUpdate
{
	/// <summary>
	/// Идентификатор пользователя, который поставил отметку.
	/// </summary>
	[JsonProperty("liker_id")]
	public long? LikerId { get; set; }

	/// <summary>
	/// Тип материала.
	/// </summary>
	[JsonProperty("object_type")]
	public LikeObjectType ObjectType { get; set; }

	/// <summary>
	/// Идентификатор владельца материала.
	/// </summary>
	[JsonProperty("object_owner_id")]
	public long? ObjectOwnerId { get; set; }

	/// <summary>
	/// Идентификатор материала.
	/// </summary>
	[JsonProperty("object_id")]
	public long? ObjectId { get; set; }

	/// <summary>
	/// Идентификатор родительского комментария/записи.
	/// </summary>
	[JsonProperty("thread_reply_id")]
	public long? ThreadReplyId { get; set; }

	/// <summary>
	/// Идентификатор записи (возвращается для комментария, оставленного под записью).
	/// </summary>
	[JsonProperty("post_id")]
	public long? PostId { get; set; }
}