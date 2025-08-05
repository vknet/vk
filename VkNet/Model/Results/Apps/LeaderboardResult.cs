using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Результат получения журнала лидеров
/// </summary>
[Serializable]
public class LeaderboardResult
{
	/// <summary>
	/// Количество побед
	/// </summary>
	[JsonProperty(propertyName: "count")]
	public long Count { get; set; }

	/// <summary>
	/// Список лидеров
	/// </summary>
	[JsonProperty(propertyName: "items")]
	public ReadOnlyCollection<LeaderboardItem> Items { get; set; }

	/// <summary>
	/// Список профилей
	/// </summary>
	[JsonProperty(propertyName: "profiles")]
	public ReadOnlyCollection<User> Profiles { get; set; }
}