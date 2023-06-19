using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Добавление/редактирование/восстановление комментария к товару
/// (<c>MarketCommentNew</c>, <c>MarketCommentEdit</c>, <c>MarketCommentRestore</c>)
/// (<c>Comment</c> с дополнительными полями)
/// </summary>
[Serializable]
public class MarketCommentGroupUpdate : Comment, IGroupUpdate
{
	/// <summary>
	/// Идентификатор товара
	/// </summary>
	[JsonProperty("item_id")]
	public ulong? ItemId { get; set; }

	/// <summary>
	/// Идентификатор владельца товара
	/// </summary>
	[JsonProperty("market_owner_id")]
	public long? MarketOwnerId { get; set; }
}