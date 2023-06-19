using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Удаление пользователя из чёрного списка
/// </summary>
[Serializable]
public class UserUnblock : IGroupUpdate
{
	/// <summary>
	/// Идентификатор пользователя
	/// </summary>
	[JsonProperty("user_id")]
	public long? UserId { get; set; }

	/// <summary>
	/// Идентификатор администратора, который убрал пользователя из чёрного списка
	/// </summary>
	[JsonProperty("admin_id")]
	public long? AdminId { get; set; }

	/// <summary>
	/// Была ли разблокировка по окончанию блокировки
	/// </summary>
	[JsonProperty("by_end_date")]
	public bool? ByEndDate { get; set; }
}