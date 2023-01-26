using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Ответ при поиске диалогов по строке поиска.
/// См. описание http://vk.com/dev/messages.searchDialogs
/// </summary>
[Serializable]
public class SearchDialogsResponse
{
	/// <summary>
	/// Список найденных пользователей.
	/// </summary>
	[JsonProperty("profiles")]
	public IList<User> Users { get; set; }

	/// <summary>
	/// Список найденных бесед.
	/// </summary>
	[JsonProperty("chats")]
	public IList<Chat> Chats { get; set; }

	/// <summary>
	/// Список найденных сообществ.
	/// </summary>
	[JsonProperty("groups")]
	public IList<Group> Groups { get; set; }
}