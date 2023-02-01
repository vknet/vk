using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Utils;

namespace VkNet.Model.Attachments;

/// <summary>
/// Комментарий к записи на стене.
/// </summary>
[Serializable]
public class WallReply : MediaAttachment
{
	/// <inheritdoc />
	protected override string Alias => "wall_reply";

	/// <summary>
	/// Идентификатор автора комментария.
	/// </summary>
	[JsonProperty("from_id")]
	public long? FromId { get; set; }

	/// <summary>
	/// Дата создания комментария в формате Unixtime.
	/// </summary>
	[JsonProperty("date")]
	[JsonConverter(typeof(UnixDateTimeConverter))]
	public DateTime? Date { get; set; }

	/// <summary>
	/// Текст комментария.
	/// </summary>
	[JsonProperty("text")]
	public string Text { get; set; }

	/// <summary>
	/// Информация о лайках к комментарию.
	/// </summary>
	[JsonProperty("likes")]
	public Likes Likes { get; set; }

	/// <summary>
	/// Идентификатор пользователя, в ответ которому был оставлен комментарий;
	/// </summary>
	[JsonProperty("reply_to_uid")]
	public long? ReplyToUId { get; set; }

	/// <summary>
	/// Идентификатор комментария, в ответ на который был оставлен текущий.
	/// </summary>
	[JsonProperty("reply_to_cid")]
	public long? ReplyToCId { get; set; }

	[JsonProperty("comment_id")]
	private long? CommentId
	{
		get => Id;
		set => Id = value;
	}

	[JsonProperty("cid")]
	private long? Cid
	{
		get => Id;
		set => Id = value;
	}

	[JsonProperty("uid")]
	private long? Uid
	{
		get => FromId;
		set => FromId = value;
	}

	[JsonProperty("user_id")]
	private long? UserId
	{
		get => FromId;
		set => FromId = value;
	}

	/// <summary>
	/// Разобрать из json.
	/// </summary>
	/// <param name="response"> Ответ сервера. </param>
	/// <returns> </returns>
	public static WallReply FromJson(VkResponse response)
	{
		var wallReply = new WallReply
		{
			Id = response["comment_id"] ?? response["cid"] ?? response["id"],
			FromId = response["from_id"] ?? response["user_id"] ?? response["uid"],
			Date = response["date"],
			Text = response["text"],
			Likes = response["likes"],
			ReplyToUId = response["reply_to_uid"],
			ReplyToCId = response["reply_to_cid"]
		};

		return wallReply;
	}

	/// <summary>
	/// Преобразование класса <see cref="WallReply" /> в <see cref="VkParameters" />
	/// </summary>
	/// <param name="response"> Ответ сервера. </param>
	/// <returns>Результат преобразования в <see cref="WallReply" /></returns>
	public static implicit operator WallReply(VkResponse response)
	{
		if (response == null)
		{
			return null;
		}

		return response.HasToken()
			? FromJson(response)
			: null;
	}
}