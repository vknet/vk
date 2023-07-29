using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Информация о количестве комментариев к записи.
/// См. описание http://vk.com/dev/post
/// </summary>
[Serializable]
public class Comments
{
	/// <summary>
	/// Количество комментариев к записи.
	/// </summary>
	[JsonProperty("count")]
	public int Count { get; set; }

	/// <summary>
	/// Признак может ли текущий пользователь добавить комментарий к записи.
	/// </summary>
	[JsonProperty("can_post")]
	public bool CanPost { get; set; }

	/// <summary>
	/// Информация о том, могут ли сообщества комментировать запись..
	/// </summary>
	[JsonProperty("groups_can_post")]
	public bool GroupsCanPost { get; set; }

	/// <summary>
	/// Признак возможности закрыть запись
	/// </summary>
	[JsonProperty("can_close")]
	public bool CanClose { get; set; }

	/// <summary>
	/// Признак возможности открыть запись
	/// </summary>
	[JsonProperty("can_open")]
	public bool CanOpen { get; set; }

	/// <summary>
	/// Комментарии
	/// </summary>
	[JsonProperty("list")]
	public ReadOnlyCollection<Comment> List { get; set; }
}