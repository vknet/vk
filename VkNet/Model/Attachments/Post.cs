﻿using VkNet.Enums.SafetyEnums;

namespace VkNet.Model
{
	using System;
	using System.Linq;
	using System.Collections.ObjectModel;
	using System.Diagnostics;

	using Attachments;
	using Utils;

	/// <summary>
	/// Запись со стены пользователя или сообщества.
	/// </summary>
	/// <remarks>
	/// См. описание <see href="http://vk.com/dev/post"/>.
	/// </remarks>
	[DebuggerDisplay("[{Id}] {Text}")]
	[Serializable]
	public class Post : MediaAttachment
	{
		/// <summary>
		/// Пост.
		/// </summary>
		static Post()
		{
			RegisterType(typeof(Post), "post");
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
		public bool FriendsOnly { get; set; }
		/// <summary>
		/// Информация о комментариях к записи.
		/// </summary>
		public Comments Comments
		{
			get;
			set;
		}
		/// <summary>
		/// Информация о лайках к записи.
		/// </summary>
		public Likes Likes
		{
			get;
			set;
		}
		/// <summary>
		/// Информация о репостах записи («Рассказать друзьям»).
		/// </summary>
		public Reposts Reposts
		{
			get;
			set;
		}

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
		public Attachment Attachment
		{
			get { return Attachments.FirstOrDefault(); }
		}

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
		#endregion

		#region Методы

		internal static Post FromJson(VkResponse response)
		{
			if (response["id"] == null)
			{
				return null;
			}
			var post = new Post
			{
				Id = response["id"],
				OwnerId = response["owner_id"],
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
				CanPin = response["can_pin"]
			};

			return post;
		}

		#endregion
	}
}