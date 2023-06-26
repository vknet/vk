using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Удаление комментария к товару (<c>MarketCommentDelete</c>)
/// </summary>
[Serializable]
public class MarketCommentDelete : IGroupUpdate
{
	/// <summary>
	/// Идентификатор комментария
	/// </summary>
	[JsonProperty("id")]
	public ulong? Id { get; set; }

	/// <summary>
	/// Идентификатор товара
	/// </summary>
	[JsonProperty("item_id")]
	public ulong? ItemId { get; set; }

	/// <summary>
	/// Идентификатор владельца товара
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