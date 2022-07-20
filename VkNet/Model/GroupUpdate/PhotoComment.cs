using System;
using VkNet.Model.Attachments;
using VkNet.Utils;

namespace VkNet.Model.GroupUpdate
{
	/// <summary>
	/// Добавление/редактирование/восстановление комментария к фотографии
	/// (<c>PhotoCommentNew</c>, <c>PhotoCommentEdit</c>, <c>PhotoCommentRestore</c>)
	/// (<c>Comment</c> с дополнительными полями)
	/// </summary>
	[Serializable]
	public class PhotoComment : Comment, IGroupUpdate
	{
		/// <summary>
		/// Идентификатор фотографии
		/// </summary>
		public long? PhotoId { get; set; }

		/// <summary>
		/// Идентификатор владельца фотографии
		/// </summary>
		public long? PhotoOwnerId { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		public new static PhotoComment FromJson(VkResponse response)
		{
			return new PhotoComment
			{
				Id = response[key: "id"],
				FromId = response[key: "from_id"],
				Date = response[key: "date"],
				Text = response[key: "text"],
				ReplyToUser = response[key: "reply_to_user"],
				ReplyToComment = response[key: "reply_to_comment"],
				Attachments = response[key: "attachments"].ToReadOnlyCollectionOf<Attachment>(selector: x => x),
				Likes = response[key: "likes"],
				PhotoId = response["photo_id"],
				PhotoOwnerId = response["photo_owner_id"]
			};
		}

		/// <summary>
		/// Преобразование класса <see cref="PhotoComment" /> в <see cref="VkParameters" />
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> Результат преобразования в <see cref="PhotoComment" /> </returns>
		public static implicit operator PhotoComment(VkResponse response)
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
}