using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Элемент журнала лидеров
/// </summary>
[Serializable]
public class LeaderboardItem
{
	/// <summary>
	/// Оценка
	/// </summary>
	[JsonProperty(propertyName: "score")]
	public long Score { get; set; }

	/// <summary>
	/// Уровень
	/// </summary>
	[JsonProperty(propertyName: "level")]
	public long Level { get; set; }

	/// <summary>
	/// Очки
	/// </summary>
	[JsonProperty(propertyName: "points")]
	public long Points { get; set; }

	/// <summary>
	/// Идентификатор пользователя
	/// </summary>
	[JsonProperty(propertyName: "user_id")]
	public long UserId { get; set; }
}