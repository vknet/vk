using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Добавление/редактирование/восстановление комментария к видео
/// (<c>VideoCommentNew</c>, <c>VideoCommentEdit</c>, <c>VideoCommentRestore</c>)
/// (<c>Comment</c> с дополнительными полями)
/// </summary>
[Serializable]
public class VideoComment : Comment, IGroupUpdate
{
	/// <summary>
	/// Идентификатор видеозаписи
	/// </summary>
	[JsonProperty("video_id")]
	public long? VideoId { get; set; }

	/// <summary>
	/// Идентификатор владельца видеозаписи
	/// </summary>
	[JsonProperty("video_owner_id")]
	public long? VideoOwnerId { get; set; }
}