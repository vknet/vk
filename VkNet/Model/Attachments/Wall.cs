using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Enums.StringEnums;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model;

/// <summary>
/// Запись со стены пользователя или сообщества. Используется для отправки
/// сообщений
/// </summary>
/// <remarks>
/// См. описание http://vk.com/dev/post
/// </remarks>
[DebuggerDisplay("[{Id}] {Text}")]
[Serializable]
public class Wall : MediaAttachment
{
	/// <inheritdoc />
	protected override string Alias => "wall";

	/// <summary>
	/// Идентификатор автора записи.
	/// </summary>
	[JsonProperty("from_id")]
	public long? FromId { get; set; }

	/// <summary>
	/// Идентификатор создателя записи в группе или паблике (тот, кто фактически ее
	/// написал)
	/// </summary>
	[JsonProperty("created_by")]
	public long? CreatedBy { get; set; }

	/// <summary>
	/// Время публикации записи.
	/// </summary>
	[JsonProperty("date")]
	[JsonConverter(typeof(UnixDateTimeConverter))]
	public DateTime? Date { get; set; }

	/// <summary>
	/// Текст записи.
	/// </summary>
	[JsonProperty("text")]
	public string Text { get; set; }

	/// <summary>
	/// Идентификатор владельца записи, в ответ на которую была оставлена текущая.
	/// </summary>
	[JsonProperty("reply_owner_id")]
	public long? ReplyOwnerId { get; set; }

	/// <summary>
	/// Идентификатор записи, в ответ на которую была оставлена текущая.
	/// </summary>
	[JsonProperty("reply_post_id")]
	public long? ReplyPostId { get; set; }

	/// <summary>
	/// <c> true </c>, если запись была создана с опцией «Только для друзей»,
	/// <c> false </c> в противном случае.
	/// </summary>
	[JsonProperty("friends_only")]
	public bool? FriendsOnly { get; set; }

	/// <summary>
	/// Информация о комментариях к записи.
	/// </summary>
	[JsonProperty("comments")]
	public Comments Comments { get; set; }

	/// <summary>
	/// Информация о лайках к записи.
	/// </summary>
	[JsonProperty("likes")]
	public Likes Likes { get; set; }

	/// <summary>
	/// Информация о репостах записи («Рассказать друзьям»).
	/// </summary>
	[JsonProperty("reposts")]
	public Reposts Reposts { get; set; }

	/// <summary>
	/// Информация о просмотрах записи.
	/// </summary>
	[JsonProperty("views")]
	public PostView Views { get; set; }

	/// <summary>
	/// Тип записи (<c>post</c>, <c>copy</c>, <c>reply</c>, <c>postpone</c>, <c>suggest</c>). Если <c>PostType</c> равен <c>"copy"</c>,
	/// то запись является копией записи с
	/// чужой стены.
	/// </summary>
	[JsonProperty("post_type")]
	public PostType PostType { get; set; }

	/// <summary>
	/// Информация о способе размещения записи.
	/// </summary>
	[JsonProperty("post_source")]
	public PostSource PostSource { get; set; }

	/// <summary>
	/// Информация о вложениях записи (фотографии ссылки и т.п.).
	/// </summary>
	[JsonProperty("attachments")]
	[JsonConverter(typeof(AttachmentJsonConverter))]
	public ReadOnlyCollection<Attachment> Attachments { get; set; }

	/// <summary>
	/// Информация о местоположении.
	/// </summary>
	[JsonProperty("geo")]
	public Geo Geo { get; set; }

	/// <summary>
	/// Идентификатор автора, если запись была опубликована от имени сообщества и
	/// подписана пользователем.
	/// </summary>
	[JsonProperty("signer_id")]
	public long? SignerId { get; set; }

	/// <summary>
	/// Массив, содержащий историю репостов для записи. Возвращается только в том
	/// случае, если запись является репостом.
	/// </summary>
	[JsonProperty("copy_history")]
	public ReadOnlyCollection<Post> CopyHistory { get; set; }

	/// <summary>
	/// Информация о том, может ли текущий пользователь закрепить запись (1 — может, 0
	/// — не может)
	/// </summary>
	[JsonProperty("can_pin")]
	public bool CanPin { get; set; }

	/// <summary>
	/// Информация о том, может ли текущий пользователь удалить эту запись.
	/// </summary>
	[JsonProperty("can_delete")]
	public bool CanDelete { get; set; }

	/// <summary>
	/// Информация о том, может ли текущий пользователь редактировать эту запись.
	/// </summary>
	[JsonProperty("can_edit")]
	public bool CanEdit { get; set; }

	/// <summary>
	/// Если запись закрепленная - вернет <c>true</c>
	/// </summary>
	[JsonProperty("is_pinned")]
	public bool? IsPinned { get; set; }

	/// <summary>
	/// Информация о том, содержит ли запись отметку "реклама"
	/// </summary>
	[JsonProperty("marked_as_ads")]
	public bool MarkedAsAds { get; set; }

	/// <summary>
	/// Приведение к <c> Wall </c> из <c> Post </c>
	/// </summary>
	/// <param name="post"> </param>
	public static explicit operator Wall(Post post) => new()
	{
		Id = post.Id,
		OwnerId = post.OwnerId,
		FromId = post.FromId,
		Date = post.Date,
		Text = post.Text,
		ReplyOwnerId = post.ReplyOwnerId,
		ReplyPostId = post.ReplyPostId,
		FriendsOnly = post.FriendsOnly,
		Comments = post.Comments,
		Likes = post.Likes,
		Reposts = post.Reposts,
		PostType = post.PostType,
		PostSource = post.PostSource,
		Attachments = post.Attachments,
		Geo = post.Geo,
		SignerId = post.SignerId,
		CopyPostDate = post.CopyPostDate,
		CopyPostType = post.CopyPostType,
		CopyOwnerId = post.CopyOwnerId,
		CopyPostId = post.CopyPostId,
		CopyText = post.CopyText,
		CopyHistory = post.CopyHistory,
		IsPinned = post.IsPinned,
		CreatedBy = post.CreatedBy,
		CopyCommenterId = post.CopyCommenterId,
		CopyCommentId = post.CopyCommentId,
		CanDelete = post.CanDelete,
		CanEdit = post.CanEdit,
		CanPin = post.CanPin,
		Views = post.Views,
		MarkedAsAds = post.MarkedAsAds
	};

	#region Поля, установленные экспериментально

	/// <summary>
	/// Текст комментария, добавленного при копировании (если запись является копией
	/// записи с чужой стены).
	/// </summary>
	[JsonProperty("copy_text")]
	public string CopyText { get; set; }

	/// <summary>
	/// Тип записи-оригинала (если запись является копией записи с чужой стены).
	/// </summary>
	[JsonProperty("copy_post_type")]
	public string CopyPostType { get; set; }

	/// <summary>
	/// Идентификатор скопированной записи на стене ее владельца (если запись является
	/// копией записи с чужой стены).
	/// </summary>
	[JsonProperty("copy_post_id")]
	public long? CopyPostId { get; set; }

	/// <summary>
	/// Идентификатор владельца стены, у которого была скопирована запись (если запись
	/// является копией записи с чужой
	/// стены).
	/// </summary>
	[JsonProperty("copy_owner_id")]
	public long? CopyOwnerId { get; set; }

	/// <summary>
	/// Время публикации записи-оригинала (если запись является копией записи с чужой
	/// стены).
	/// </summary>
	[JsonProperty("copy_post_date")]
	[JsonConverter(typeof(UnixDateTimeConverter))]
	public DateTime? CopyPostDate { get; set; }

	/// <summary>
	/// Если запись является копией записи с чужой стены, то в этом поле содержится
	/// идентификатор коментатора записи.
	/// </summary>
	[JsonProperty("copy_commenter_id")]
	public long? CopyCommenterId { get; set; }

	/// <summary>
	/// Если запись является копией записи с чужой стены, то в этом поле содержится
	/// идентификатор коментария.
	/// </summary>
	[JsonProperty("copy_comment_id")]
	public long? CopyCommentId { get; set; }

	#endregion
}