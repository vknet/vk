using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model.Attachments
{
	/// <summary>
	/// Запись со стены пользователя или сообщества.
	/// </summary>
	/// <remarks>
	/// См. описание http://vk.com/dev/post
	/// </remarks>
	[DebuggerDisplay("[{Id}] {Text}")]
	[Serializable]
	public class Post : MediaAttachment
	{
		/// <inheritdoc />
		protected override string Alias => "post";

		/// <summary>
		/// Идентификатор автора записи.
		/// </summary>
		public long? FromId { get; set; }

		/// <summary>
		/// Время публикации записи.
		/// </summary>
		[JsonConverter(typeof(UnixDateTimeConverter))]
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
		/// Тип записи (<c>post</c>, <c>copy</c>, <c>reply</c>, <c>postpone</c>, <c>suggest</c>). Если <c>PostType</c> равен <c>"copy"</c>,
		/// то запись является копией записи с
		/// чужой стены.
		/// </summary>
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public PostType PostType { get; set; }

		/// <summary>
		/// Информация о способе размещения записи.
		/// </summary>
		public PostSource PostSource { get; set; }

		/// <summary>
		/// Информация о вложениях записи (фотографии ссылки и т.п.).
		/// </summary>
		[JsonConverter(typeof(AttachmentJsonConverter))]
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
		/// Если запись закрепленная - вернет <c>true</c>
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
		[JsonConverter(typeof(UnixDateTimeConverter))]
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
		/// Разобрать из JSON
		/// </summary>
		/// <param name="response"> Ответ сервера </param>
		/// <returns> </returns>
		public static Post FromJson(VkResponse response)
		{
			if (response["id"] == null)
			{
				return null;
			}

			var res = new Post()
			{
				Id = response["id"],
				OwnerId = response["owner_id"],
				FromId = response["from_id"],
				Date = response["date"],
				Text = response["text"],
				ReplyOwnerId = response["reply_owner_id"],
				ReplyPostId = response["reply_post_id"],
				FriendsOnly = response["friends_only"],
				SignerId = response["signer_id"],
				CopyPostDate = response["copy_post_date"],
				CopyPostType = response["copy_post_type"],
				CopyOwnerId = response["copy_owner_id"],
				CopyPostId = response["copy_post_id"],
				CopyText = response["copy_text"],
				IsPinned = response["is_pinned"],
				CreatedBy = response["created_by"],
				CopyCommenterId = response["copy_commenter_id"],
				CopyCommentId = response["copy_comment_id"],
				CanDelete = response["can_delete"],
				CanEdit = response["can_edit"],
				CanPin = response["can_pin"],
				MarkedAsAds = response["marked_as_ads"],
				AccessKey = response["access_key"]
			};
			res.Comments = response["comments"];
			res.Likes = response["likes"];
			res.Reposts = response["reposts"];
			res.PostType = response["post_type"];
			res.PostSource = response["post_source"];
			res.Geo = response["geo"];
			res.Attachments = response["attachments"].ToReadOnlyCollectionOf<Attachment>(x => x);
			res.CopyHistory = response["copy_history"].ToReadOnlyCollectionOf<Post>(x => x);
			res.Views = response["views"];
			res.Donut = response["donut"];

			return res;
		}

		/// <summary>
		/// Преобразование класса <see cref="Post" /> в <see cref="VkParameters" />
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns>Результат преобразования в <see cref="Post" /></returns>
		public static implicit operator Post(VkResponse response)
		{
			if (response == null)
			{
				return null;
			}

			return response.HasToken()
				? FromJson(response)
				: null;
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
		[JsonProperty("access_key")]
		public string AccessKey { get; set; }

		/// <summary>
		/// Информация о записи VK Donut.
		/// </summary>
		[JsonProperty("donut")]
		public PostDonut Donut { get; set; }

	#endregion
	}
}