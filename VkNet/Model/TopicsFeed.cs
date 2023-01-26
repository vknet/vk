using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Новости
/// </summary>
[Serializable]
public class TopicsFeed
{
	/// <summary>
	/// Количество.
	/// </summary>
	[JsonProperty("count")]
	public int Count { get; set; }

	/// <summary>
	/// Массив комментариев.
	/// </summary>
	[JsonProperty("items")] //TODO:
	public ReadOnlyCollection<CommentBoard> Items { get; set; }

	/// <summary>
	/// Информация о пользователях, которые находятся в списке комментариев.
	/// </summary>
	[JsonProperty("profiles")]
	public ReadOnlyCollection<User> Profiles { get; set; }

	/// <summary>
	/// Информация о группах, которые находятся в списке комментариев.
	/// </summary>
	[JsonProperty("groups")]
	public ReadOnlyCollection<Group> Groups { get; set; }
}