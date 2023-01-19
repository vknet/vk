using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model;

/// <summary>
/// Subscriptions
/// </summary>
[Serializable]
public class SubscriptionsInfo
{
	/// <summary>
	/// Массив объектов подписок.
	/// </summary>
	[JsonProperty("subscritions")]
	public IEnumerable<Subscription> Subscriptions { get; set; }

	/// <summary>
	/// Количество подписок.
	/// </summary>
	[JsonProperty("count")]
	public long Count { get; set; }

	/// <summary>
	/// Массив объектов пользователей.
	/// </summary>
	[JsonProperty("profiles")]
	public IEnumerable<User> Profiles { get; set; }

	/// <summary>
	/// Массив объектов сообществ.
	/// </summary>
	[JsonProperty("groups")]
	public IEnumerable<Group> Groups { get; set; }
}