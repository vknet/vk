using System.Runtime.Serialization;
using VkNet.Enums.SafetyEnums;

namespace VkNet.Model
{
	using System;
	using System.Linq;
	using System.Collections.ObjectModel;
	using System.Diagnostics;

	using Attachments;
	using Utils;

	/// <summary>
	/// Запись со стены пользователя или сообщества. Используется для отправки сообщений
	/// </summary>
	/// <remarks>
	/// См. описание http://vk.com/dev/post
	/// </remarks>
	[DebuggerDisplay("[{Id}] {Text}")]
	[Serializable]
	public class Wall : MediaAttachment
	{
		/// <summary>
		/// Пост.
		/// </summary>
		static Wall()
		{
			RegisterType(typeof(Wall), "wall");
		}

		/// <summary>
		/// Идентификатор автора записи.
		/// </summary>
		public long? FromId { get; set; }

		/// <summary>
		/// Время публикации записи.
		/// </summary>
		public DateTime? Date { get; set; }

		/// <summary>
		/// Текст записи.
		/// </summary>
		public string Text { get; set; }

		/// <summary>
		/// Идентификатор владельца записи, в ответ на которую была оставлена текущая.
		/// </summary>
		public long? ReplyOwnerId { get; set; }

		/// <summary>
		/// Идентификатор записи, в ответ на которую была оставлена текущая.
		/// </summary>
		public long? ReplyPostId { get; set; }

		/// <summary>
		/// <c>true</c>, если запись была создана с опцией «Только для друзей», <c>false</c> в противном случае.
		/// </summary>
		public bool? FriendsOnly { get; set; }
		/// <summary>
		/// Информация о комментариях к записи.
		/// </summary>
		public Comments Comments { get; set; }
		/// <summary>
		/// Информация о лайках к записи.
		/// </summary>
		public Likes Likes { get; set; }
		/// <summary>
		/// Информация о репостах записи («Рассказать друзьям»).
		/// </summary>
		public Reposts Reposts { get; set; }

		/// <summary>
		/// Информация о просмотрах записи. 
		/// </summary>
		public PostView Views { get; set; }

		/// <summary>
		/// Тип записи (post, copy, reply, postpone, suggest). Если PostType равен "copy", то запись является копией записи с чужой стены.
		/// </summary>
		public PostType PostType { get; set; }

		/// <summary>
		/// Информация о способе размещения записи.
		/// </summary>
		public PostSource PostSource { get; set; }

		/// <summary>
		/// Информация о вложениях записи (фотографии ссылки и т.п.).
		/// </summary>
		public ReadOnlyCollection<Attachment> Attachments { get; set; }

		/// <summary>
		/// Первое вложение.
		/// </summary>
		public Attachment Attachment => Attachments.FirstOrDefault();

		/// <summary>
		/// Информация о местоположении.
		/// </summary>
		public Geo Geo { get; set; }

		/// <summary>
		/// Если запись закрепленная - вернет true
		/// </summary>
		public bool? IsPinned { get; set; }

		/// <summary>
		/// Идентификатор автора, если запись была опубликована от имени сообщества и подписана пользователем.
		/// </summary>
		public long? SignerId { get; set; }

		/// <summary>
		/// Время публикации записи-оригинала (если запись является копией записи с чужой стены).
		/// </summary>
		public DateTime? CopyPostDate { get; set; }

		/// <summary>
		/// Тип записи-оригинала (если запись является копией записи с чужой стены).
		/// </summary>
		public string CopyPostType { get; set; }

		/// <summary>
		/// Идентификатор владельца стены, у которого была скопирована запись (если запись является копией записи с чужой стены).
		/// </summary>
		public long? CopyOwnerId { get; set; }

		/// <summary>
		/// Идентификатор скопированной записи на стене ее владельца (если запись является копией записи с чужой стены).
		/// </summary>
		public long? CopyPostId { get; set; }

		/// <summary>
		/// Текст комментария, добавленного при копировании (если запись является копией записи с чужой стены).
		/// </summary>
		public string CopyText { get; set; }

		/// <summary>
		/// Массив, содержащий историю репостов для записи. Возвращается только в том случае, если запись является репостом.
		/// </summary>
		public Collection<Post> CopyHistory { get; set; }

		#region Поля, установленные экспериментально

		/// <summary>
		/// Идентификатор создателя записи в группе или паблике (тот, кто фактически ее написал)
		/// </summary>
		public long? CreatedBy { get; set; }

		/// <summary>
		/// Если запись является копией записи с чужой стены, то в этом поле содержится идентификатор коментатора записи.
		/// </summary>
		public long? CopyCommenterId { get; set; }

		/// <summary>
		/// Если запись является копией записи с чужой стены, то в этом поле содержится идентификатор коментария.
		/// </summary>
		public long? CopyCommentId { get; set; }

		/// <summary>
		/// Признак может ли текущий пользователь удалить эту запись.
		/// </summary>
		public bool CanDelete { get; set; }

		/// <summary>
		/// Признак может ли текущий пользователь редактировать эту запись.
		/// </summary>
		public bool CanEdit { get; set; }

		/// <summary>
		/// Информация о том, может ли текущий пользователь закрепить запись (1 — может, 0 — не может)
		/// </summary>
		public bool CanPin { get; set; }

		/// <summary>
		/// Информация о том, содержит ли запись отметку "реклама"
		/// </summary>
		public bool MarkedAsAds { get; set; }
		#endregion

		#region Методы

		/// <summary>
		/// Парсинг из JSON
		/// </summary>
		/// <param name="response"></param>
		/// <returns></returns>
		public static Wall FromJson(VkResponse response)
		{
			if (response["id"] == null)
			{
				return null;
			}
			var post = new Wall
			{
				Id = response["id"],
				OwnerId = response["to_id"],
				FromId = response["from_id"],
				Date = response["date"],
				Text = response["text"],
				ReplyOwnerId = response["reply_owner_id"],
				ReplyPostId = response["reply_post_id"],
				FriendsOnly = response["friends_only"],
				Comments = response["comments"],
				Likes = response["likes"],
				Reposts = response["reposts"],
				PostType = response["post_type"],
				PostSource = response["post_source"],
				Attachments = response["attachments"].ToReadOnlyCollectionOf<Attachment>(x => x),
				Geo = response["geo"],
				SignerId = response["signer_id"],
				CopyPostDate = response["copy_post_date"],
				CopyPostType = response["copy_post_type"],
				CopyOwnerId = response["copy_owner_id"],
				CopyPostId = response["copy_post_id"],
				CopyText = response["copy_text"],
				CopyHistory = response["copy_history"],
				IsPinned = response["is_pinned"],
				CreatedBy = response["created_by"],
				CopyCommenterId = response["copy_commenter_id"],
				CopyCommentId = response["copy_comment_id"],
				CanDelete = response["can_delete"],
				CanEdit = response["can_edit"],
				CanPin = response["can_pin"],
				Views = response["views"],
				MarkedAsAds = response["marked_as_ads"]
			};

			return post;
		}

		#endregion

		/// <summary>
		/// Приведение к <c>Wall</c> из <c>Post</c>
		/// </summary>
		/// <param name="post"></param>
		public static explicit operator Wall(Post post)
		{
			return new Wall()
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
		}
	}
}