using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Элемент пользовательского списка новостей
/// </summary>
[Serializable]
public class NewsUserListItem
{
	/// <summary>
	/// Идентификатор списка.
	/// </summary>
	[JsonProperty("id")]
	public int Id { get; set; }

	/// <summary>
	/// Название списка, заданное пользователем.
	/// </summary>
	[JsonProperty("title")]
	public string Title { get; set; }

	/// <summary>
	/// Отключены ли копии постов;
	/// </summary>
	[JsonProperty("no_reposts")]
	public bool? NoReposts { get; set; }

	/// <summary>
	/// Идентификаторы пользователей и сообществ, включенных в список.
	/// </summary>
	[JsonProperty("source_ids")]
	public IEnumerable<long> SourceIds { get; set; }
}