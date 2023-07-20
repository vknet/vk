using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model;

/// <summary>
/// Комментарий в обсуждении
/// </summary>
[Serializable]
public class CommentBoard
{
	/// <summary>
	/// Идентификатор комментария.
	/// </summary>
	[JsonProperty(propertyName: "id")]
	public long Id { get; set; }

	/// <summary>
	/// Идентификатор автора комментария.
	/// </summary>
	[JsonProperty(propertyName: "from_id")]
	public long FromId { get; set; }

	/// <summary>
	/// Дата создания (в формате Unixtime).
	/// </summary>
	[JsonProperty(propertyName: "date")]
	[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
	public DateTime Date { get; set; }

	/// <summary>
	/// Текст комментария.
	/// </summary>
	[JsonProperty(propertyName: "text")]
	public string Text { get; set; }

	/// <summary>
	/// Медиавложения комментария (фотографии, ссылки и т.п.).
	/// </summary>
	[JsonProperty(propertyName: "attachments")]
	[JsonConverter(converterType: typeof(AttachmentJsonConverter))]
	public ReadOnlyCollection<Attachment> Attachments { get; set; }

	/// <summary>
	/// Информация об отметках «Мне нравится» текущего комментария (если был задан
	/// параметр need_likes)
	/// </summary>
	[JsonProperty(propertyName: "likes")]
	public Likes Likes { get; set; }
}