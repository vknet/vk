using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace VkNet.Model;

/// <summary>
/// Упоминание.
/// </summary>
[Serializable]
public class Mention
{
	/// <summary>
	/// Идентификатор записи на стене пользователя.
	/// </summary>
	[JsonProperty("id")]
	public ulong Id { get; set; }

	/// <summary>
	/// Идентификатор пользователя, написавшего запись.
	/// </summary>
	[JsonProperty("from_id")]
	public ulong FromId { get; set; }

	/// <summary>
	/// Время публикаии записи в формате unixtime.
	/// </summary>
	[JsonProperty("date")]
	[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
	public DateTime? Date { get; set; }

	/// <summary>
	/// Текст записи.
	/// </summary>
	[JsonProperty("text")]
	public string Text { get; set; }

	/// <summary>
	/// Содержит информацию о числе людей, которым понравилась данная запись, и
	/// понравилась ли она текущему пользователю.
	/// </summary>
	[JsonProperty("likes")]
	public Likes Likes { get; set; }

	/// <summary>
	/// Содержит информацию о количестве комментариев к записи и возможности текущего
	/// пользователя оставлять комментарии к
	/// ней.
	/// </summary>
	[JsonProperty("comments")]
	public Comments Comments { get; set; }

	/// <summary>
	/// Содержит объект, который присоединен к текущей новости ( фотография, ссылка и
	/// т.п.). Более подробная информация
	/// представлена на странице Описание поля attachment.
	/// </summary>
	[JsonProperty("attachment")]
	public Attachment Attachment { get; set; }

	/// <summary>
	/// Находится в записях со стен, в которых имеется информация о местоположении.
	/// </summary>
	[JsonProperty("geo")]
	public Geo Geo { get; set; }

	/// <summary>
	/// Если запись является копией записи с чужой стены, то в поле содержится
	/// идентификатор владельца стены у которого
	/// была скопирована запись.
	/// </summary>
	[JsonProperty("copy_owner_id")]
	public ulong? CopyOwnerId { get; set; }

	/// <summary>
	/// Если запись является копией записи с чужой стены, то в поле содержится
	/// идентфикатор скопированной записи на стене
	/// ее владельца.
	/// </summary>
	[JsonProperty("copy_post_id")]
	public ulong? CopyPostId { get; set; }

	/// <summary>
	/// Идентификатор сообщества где было сделано упоминание.
	/// </summary>
	/// <remarks>
	/// Выведено экспериментально.
	/// </remarks>
	[JsonProperty("to_id")]
	public long? ToId { get; set; }

	/// <summary>
	/// Идентификатор поста.
	/// </summary>
	/// <remarks>
	/// Выведено экспериментально.
	/// </remarks>
	[JsonProperty("post_id")]
	public ulong? PostId { get; set; }

	/// <summary>
	/// Тип поста.
	/// </summary>
	/// <remarks>
	/// Выведено экспериментально.
	/// </remarks>
	[JsonProperty("post_type")]
	public string PostType { get; set; }

	/// <summary>
	/// Репосты.
	/// </summary>
	/// <remarks>
	/// Выведено экспериментально.
	/// </remarks>
	[JsonProperty("reposts")]
	public Reposts Reposts { get; set; }
}