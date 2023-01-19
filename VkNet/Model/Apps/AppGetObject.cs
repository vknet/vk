using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model;

/// <summary>
/// Результат выполнения запроса получения приложений
/// </summary>
[Serializable]
public class AppGetObject
{
	/// <summary>
	/// Общее количество записей на стене.
	/// </summary>
	[JsonProperty("count")]
	public ulong TotalCount { get; set; }

	/// <summary>
	/// Приложения.
	/// </summary>
	[JsonProperty("items")]
	public VkCollection<App> Apps { get; set; }

	/// <summary>
	/// Друзья.
	/// </summary>
	[JsonProperty("profiles")]
	public VkCollection<User> Friends { get; set; }
}