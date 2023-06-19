using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Enums;

namespace VkNet.Model;

/// <summary>
/// Добавление пользователя в чёрный список
/// </summary>
[Serializable]
public class UserBlock : IGroupUpdate
{
	/// <summary>
	/// Идентификатор пользователя
	/// </summary>
	[JsonProperty("user_id")]
	public long? UserId { get; set; }

	/// <summary>
	/// Идентификатор администратора, который внёс пользователя в чёрный список
	/// </summary>
	[JsonProperty("admin_id")]
	public long? AdminId { get; set; }

	/// <summary>
	/// Дата разблокировки
	/// </summary>
	[JsonProperty("unblock_date")]
	[JsonConverter(typeof(UnixDateTimeConverter))]
	public DateTime? UnblockDate { get; set; }

	/// <summary>
	/// Причины блокировки пользователя
	/// </summary>
	[JsonProperty("reason")]
	public BanReason? Reason { get; set; }

	/// <summary>
	/// Комментарий администратора к блокировке
	/// </summary>
	[JsonProperty("comment")]
	public string Comment { get; set; }
}