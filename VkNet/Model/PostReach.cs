using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Статистика для записи на стене.
/// </summary>
[Serializable]
public class PostReach
{
	/// <summary>
	/// Охват подписчиков.
	/// </summary>
	[JsonProperty("reach_subscribers")]
	public long ReachSubscribers { get; set; }

	/// <summary>
	/// Суммарный охват.
	/// </summary>
	[JsonProperty("reach_total")]
	public long ReachTotal { get; set; }

	/// <summary>
	/// Переходы по ссылке.
	/// </summary>
	[JsonProperty("links")]
	public long Links { get; set; }

	/// <summary>
	/// Переходы в сообщество.
	/// </summary>
	[JsonProperty("to_group")]
	public long ToGroup { get; set; }

	/// <summary>
	/// Вступления в сообщество.
	/// </summary>
	[JsonProperty("join_group")]
	public long JoinGroup { get; set; }

	/// <summary>
	/// Количество жалоб на запись.
	/// </summary>
	[JsonProperty("report")]
	public long Report { get; set; }

	/// <summary>
	/// Количество скрытий записи.
	/// </summary>
	[JsonProperty("hide")]
	public long Hide { get; set; }

	/// <summary>
	/// Количество отписавшихся участников.
	/// </summary>
	[JsonProperty("unsubscribe")]
	public long Unsubscribe { get; set; }
}