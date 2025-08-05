using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Enums.StringEnums;

namespace VkNet.Model;

/// <summary>
/// Результат метода fave.get
/// </summary>
[Serializable]
public class FaveGetObject
{
	/// <summary>
	/// Дата добавления объекта в закладки.
	/// </summary>
	[JsonProperty("added_date")]
	[JsonConverter(typeof(UnixDateTimeConverter))]
	public DateTime AddedDate { get; set; }

	/// <summary>
	/// Является ли закладка просмотренной.
	/// </summary>
	[JsonProperty("seen")]
	public bool Seen { get; set; }

	/// <summary>
	/// Тип объекта, добавленного в закладки.
	/// </summary>
	[JsonProperty("type")]
	public FaveType? Type { get; set; }

	/// <summary>
	/// Массив меток объекта в списке закладок.
	/// </summary>
	[JsonProperty("tags")]
	public IEnumerable<FaveTag> Tags { get; set; }

	/// <summary>
	/// Запись со стены пользователя или сообщества.
	/// </summary>
	[JsonProperty("post")]
	public Post Post { get; set; }

	/// <summary>
	/// Видеозапись пользователя или группы.
	/// </summary>
	[JsonProperty("video")]
	public Video Video { get; set; }

	/// <summary>
	/// Информация о продукте.
	/// </summary>
	[JsonProperty("product")]
	public Market Product { get; set; }

	/// <summary>
	/// Статья
	/// </summary>
	[JsonProperty("article")]
	public Article Article { get; set; }

	/// <summary>
	/// Подкаст
	/// </summary>
	[JsonProperty("podcast")]
	public Podcast Podcast { get; set; }

	/// <summary>
	/// Ссылка на Web-страницу.	///  См. описание http://vk.com/dev/attachments_w
	/// </summary>
	[JsonProperty("link")]
	public Link Link { get; set; }
}