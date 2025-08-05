using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using VkNet.Utils;

// ReSharper disable UnusedAutoPropertyAccessor.Global

// ReSharper disable MemberCanBePrivate.Global

namespace VkNet.Model;

/// <summary>
/// Обновления в личных сообщениях пользователя.
/// </summary>
[Serializable]
public class LongPollHistoryResponse<TMessage>
{
	/// <summary>
	/// Обновления в личных сообщениях пользователя.
	/// </summary>
	public LongPollHistoryResponse() => History = new();

	/// <summary>
	/// История.
	/// </summary>
	[JsonProperty("history")]

	// ReSharper disable once AutoPropertyCanBeMadeGetOnly.Global
	public List<ReadOnlyCollection<long>> History { get; set; }

	/// <summary>
	/// Количество непрочитанных сообщений
	/// </summary>
	public ulong UnreadMessages { get; set; }

	/// <summary>
	/// Колекция сообщений.
	/// </summary>
	[JsonProperty("messages")]
	public VkCollection<TMessage> Messages { get; set; }

	/// <summary>
	/// Колекция профилей.
	/// </summary>
	[JsonProperty("profiles")]
	public ReadOnlyCollection<User> Profiles { get; set; }

	/// <summary>
	/// Колекция профилей.
	/// </summary>
	[JsonProperty("groups")]
	public ReadOnlyCollection<Group> Groups { get; set; }

	/// <summary>
	/// Последнее значение параметра new_pts, полученное от Long Poll сервера,
	/// используется для получения действий, которые
	/// хранятся всегда.
	/// </summary>
	[JsonProperty("new_pts")]
	public ulong NewPts { get; set; }

	/// <summary>
	/// Если true — это означает, что нужно запросить оставшиеся данные с помощью
	/// запроса с параметром max_msg_id
	/// </summary>
	[JsonProperty("more")]
	public bool More { get; set; }
}

/// <inheritdoc />
[Serializable]
public class LongPollHistoryResponse : LongPollHistoryResponse<Message>
{
}