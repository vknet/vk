using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Удаление комментария к фотографии (<c>PhotoCommentDelete</c>)
/// </summary>
[Serializable]
public class PhotoCommentDelete : IGroupUpdate
{
	/// <summary>
	/// Идентификатор комментария
	/// </summary>
	[JsonProperty("id")]
	public ulong? Id { get; set; }

	/// <summary>
	/// Идентификатор фотографии
	/// </summary>
	[JsonProperty("photo_id")]
	public long? PhotoId { get; set; }

	/// <summary>
	/// Идентификатор владельца фотографии
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