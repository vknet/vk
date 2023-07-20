using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Результат выполнения запроса получения записей со стены
/// </summary>
[Serializable]
public class WallGetObject
{
	/// <summary>
	/// Общее количество записей на стене.
	/// </summary>
	[JsonProperty("count")]
	public ulong TotalCount { get; set; }

		/// <summary>
	/// Посты.
	/// </summary>
	[JsonProperty("items")]
	public ReadOnlyCollection<Post> WallPosts { get; set; }

	/// <summary>
	/// Профили.
	/// </summary>
	[JsonProperty("profiles")]
	public ReadOnlyCollection<User> Profiles { get; set; }

	/// <summary>
	/// Группы.
	/// </summary>
	[JsonProperty("groups")]
	public ReadOnlyCollection<Group> Groups { get; set; }
}