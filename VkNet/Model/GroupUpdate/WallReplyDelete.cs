using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Удаление комментария к записи (<c>WallReplyDelete</c>)
/// </summary>
[Serializable]
public class WallReplyDelete : IGroupUpdate
{
	/// <summary>
	/// Идентификатор комментария
	/// </summary>
	[JsonProperty("id")]
	public ulong? Id { get; set; }

	/// <summary>
	/// Идентификатор записи, к которой был оставлен комментарий
	/// </summary>
	[JsonProperty("post_id")]
	public long? PostId { get; set; }

	/// <summary>
	/// Идентификатор владельца стены
	/// </summary>
	[JsonProperty("owner_id")]
	public long? OwnerId { get; set; }

	/// <summary>
	/// Идентификатор автора комментария
	/// </summary>
	[JsonProperty("user_id")]
	public long? UserId { get; set; }

	/// <summary>
	/// Идентификатор пользователя, который удалил комментарий
	/// </summary>
	[JsonProperty("deleter_id")]
	public long? DeleterId { get; set; }
}