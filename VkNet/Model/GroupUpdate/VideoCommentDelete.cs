using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Удаление комментария к видео (<c>VideoCommentDelete</c>)
/// </summary>
[Serializable]
public class VideoCommentDelete : IGroupUpdate
{
	/// <summary>
	/// Идентификатор комментария
	/// </summary>
	[JsonProperty("id")]
	public ulong? Id { get; set; }

	/// <summary>
	/// Идентификатор видео
	/// </summary>
	[JsonProperty("video_id")]
	public long? VideoId { get; set; }

	/// <summary>
	/// Идентификатор владельца видео
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