using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace VkNet.Model;

/// <summary>
///  Комментарий к заметке
/// </summary>
[Serializable]
public class CommentNote
{
	/// <summary>
	/// идентификатор комментария
	/// </summary>
	[JsonProperty(propertyName: "id")]
	public long? Id { get; set; }

	/// <summary>
	/// идентификатор автора комментария
	/// </summary>
	[JsonProperty(propertyName: "uid")]
	public long? UserId { get; set; }

	/// <summary>
	/// идентификатор заметки
	/// </summary>
	[JsonProperty(propertyName: "nid")]
	public long? NoteId { get; set; }

	/// <summary>
	/// идентификатор владельца заметки
	/// </summary>
	[JsonProperty(propertyName: "oid")]
	public long? OwnerId { get; set; }

	/// <summary>
	/// Дата добавления комментария в формате unixtime
	/// </summary>
	[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
	[JsonProperty(propertyName: "date")]
	public DateTime? Date { get; set; }

	/// <summary>
	/// текст комментария
	/// </summary>
	[JsonProperty(propertyName: "message")]
	public string Message { get; set; }

	/// <summary>
	/// идентификатор пользователя, в ответ на комментарий которого
	/// был оставлен текущий комментарий (если доступно).
	/// </summary>
	[JsonProperty(propertyName: "reply_to")]
	public long? ReplyTo { get; set; }
}