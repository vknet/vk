using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Расширенный объект видео для закладок
/// </summary>
[Serializable]
public class FaveVideoEx
{
	/// <summary>
	/// Общее количество записей на стене.
	/// </summary>
	[JsonProperty(propertyName: "count")]
	public ulong Count { get; set; }

	/// <summary>
	/// Видеозаписи.
	/// </summary>
	[JsonProperty(propertyName: "items")]
	public ReadOnlyCollection<Video> Videos { get; set; }

	/// <summary>
	/// Профили.
	/// </summary>
	[JsonProperty(propertyName: "profiles")]
	public ReadOnlyCollection<User> Profiles { get; set; }

	/// <summary>
	/// Группы.
	/// </summary>
	[JsonProperty(propertyName: "groups")]
	public ReadOnlyCollection<Group> Groups { get; set; }
}