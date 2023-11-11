using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Добавление/редактирование/восстановление комментария к фотографии
/// (<c>PhotoCommentNew</c>, <c>PhotoCommentEdit</c>, <c>PhotoCommentRestore</c>)
/// (<c>Comment</c> с дополнительными полями)
/// </summary>
[Serializable]
public class PhotoComment : Comment, IGroupUpdate
{
	/// <summary>
	/// Идентификатор фотографии
	/// </summary>
	[JsonProperty("photo_id")]
	public new long? PhotoId { get; set; }

	/// <summary>
	/// Идентификатор владельца фотографии
	/// </summary>
	[JsonProperty("photo_owner_id")]
	public long? PhotoOwnerId { get; set; }
}