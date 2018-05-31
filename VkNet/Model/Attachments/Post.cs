using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.Attachments;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Запись со стены пользователя или сообщества.
	/// </summary>
	/// <remarks>
	/// См. описание http://vk.com/dev/post
	/// </remarks>
	[DebuggerDisplay(value: "[{Id}] {Text}")]
	[Serializable]
	public class Post : MediaAttachment
	{
		/// <summary>
		/// Пост.
		/// </summary>
		static Post()
		{
			RegisterType(type: typeof(Post), match: "post");
		}

		/// <summary>
		/// Идентификатор автора записи.
		/// </summary>
		public long? FromId { get; set; }

		/// <summary>
		/// Время публикации записи.
		/// </summary>
		[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
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
		/// <c> true </c>, если запись была создана с опцией «Только для друзей»,
		/// <c> false </c> в противном случае.
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
		/// Тип записи (post, copy, reply, postpone, suggest). Если PostType равен "copy",
		/// то запись является копией записи с
		/// чужой стены.
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
		/// Идентификатор автора, если запись была опубликована от имени сообщества и
		/// подписана пользователем.
		/// </summary>
		public long? SignerId { get; set; }

		/// <summary>
		/// Время публикации записи-оригинала (если запись является копией записи с чужой
		/// стены).
		/// </summary>
		[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
		public DateTime? CopyPostDate { get; set; }

		/// <summary>
		/// Тип записи-оригинала (если запись является копией записи с чужой стены).
		/// </summary>
		public string CopyPostType { get; set; }

		/// <summary>
		/// Идентификатор владельца стены, у которого была скопирована запись (если запись
		/// является копией записи с чужой
		/// стены).
		/// </summary>
		public long? CopyOwnerId { get; set; }

		/// <summary>
		/// Идентификатор скопированной записи на стене ее владельца (если запись является
		/// копией записи с чужой стены).
		/// </summary>
		public long? CopyPostId { get; set; }

		/// <summary>
		/// Текст комментария, добавленного при копировании (если запись является копией
		/// записи с чужой стены).
		/// </summary>
		public string CopyText { get; set; }

		/// <summary>
		/// Массив, содержащий историю репостов для записи. Возвращается только в том
		/// случае, если запись является репостом.
		/// </summary>
		public ReadOnlyCollection<Post> CopyHistory { get; set; }

	#region Методы

		/// <summary>
		/// </summary>
		/// <param name="response"> </param>
		/// <returns> </returns>
		public static Post FromJson(VkResponse response)
		{
			if (response[key: "id"] == null)
			{
				return null;
			}

			var post = new Post
			{
					Id = response[key: "id"]
					, OwnerId = response[key: "owner_id"]
					, FromId = response[key: "from_id"]
					, Date = response[key: "date"]
					, Text = response[key: "text"]
					, ReplyOwnerId = response[key: "reply_owner_id"]
					, ReplyPostId = response[key: "reply_post_id"]
					, FriendsOnly = response[key: "friends_only"]
					, Comments = response[key: "comments"]
					, Likes = response[key: "likes"]
					, Reposts = response[key: "reposts"]
					, PostType = response[key: "post_type"]
					, PostSource = response[key: "post_source"]
					, Attachments = response[key: "attachments"].ToReadOnlyCollectionOf<Attachment>(selector: x => x)
					, Geo = response[key: "geo"]
					, SignerId = response[key: "signer_id"]
					, CopyPostDate = response[key: "copy_post_date"]
					, CopyPostType = response[key: "copy_post_type"]
					, CopyOwnerId = response[key: "copy_owner_id"]
					, CopyPostId = response[key: "copy_post_id"]
					, CopyText = response[key: "copy_text"]
					, CopyHistory = response[key: "copy_history"].ToReadOnlyCollectionOf<Post>(selector: x => x)
					, IsPinned = response[key: "is_pinned"]
					, CreatedBy = response[key: "created_by"]
					, CopyCommenterId = response[key: "copy_commenter_id"]
					, CopyCommentId = response[key: "copy_comment_id"]
					, CanDelete = response[key: "can_delete"]
					, CanEdit = response[key: "can_edit"]
					, CanPin = response[key: "can_pin"]
					, Views = response[key: "views"]
					, MarkedAsAds = response[key: "marked_as_ads"]
					, AccessKey = response[key: "access_key"]
			};

			return post;
		}

	#endregion

	#region Поля, установленные экспериментально

		/// <summary>
		/// Идентификатор создателя записи в группе или паблике (тот, кто фактически ее
		/// написал)
		/// </summary>
		public long? CreatedBy { get; set; }

		/// <summary>
		/// Если запись является копией записи с чужой стены, то в этом поле содержится
		/// идентификатор коментатора записи.
		/// </summary>
		public long? CopyCommenterId { get; set; }

		/// <summary>
		/// Если запись является копией записи с чужой стены, то в этом поле содержится
		/// идентификатор коментария.
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
		/// Информация о том, может ли текущий пользователь закрепить запись (1 — может, 0
		/// — не может)
		/// </summary>
		public bool CanPin { get; set; }

		/// <summary>
		/// Информация о том, содержит ли запись отметку "реклама"
		/// </summary>
		public bool MarkedAsAds { get; set; }

		/// <summary>
		/// Ключ доступа
		/// </summary>
		[JsonProperty(propertyName: "access_key")]
		public string AccessKey { get; set; }

	#endregion
	}
}