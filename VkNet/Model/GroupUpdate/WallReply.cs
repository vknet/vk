using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Добавление/редактирование/восстановление комментария на стене
/// (<c>WallReplyNew</c>, <c>WallReplyEdit</c>, <c>WallReplyRestore</c>)
/// (<c>Comment</c> с дополнительными полями)
/// </summary>
[Serializable]
public class WallReplyGroupUpdate : Comment, IGroupUpdate
{
	/// <summary>
	/// Идентификатор записи
	/// </summary>
	[JsonProperty("post_id")]
	public long? PostId { get; set; }

	/// <summary>
	/// Идентификатор владельца записи
	/// </summary>
	[JsonProperty("post_owner_id")]
	public long? PostOwnerId { get; set; }
}