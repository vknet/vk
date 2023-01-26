using System;
using System.Collections.Generic;
using Newtonsoft.Json;

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
	public IEnumerable<App> Apps { get; set; }

	/// <summary>
	/// Друзья.
	/// </summary>
	[JsonProperty("profiles")]
	public IEnumerable<User> Friends { get; set; }
}