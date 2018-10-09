using System;
using VkNet.Model.Attachments;
using VkNet.Utils;

namespace VkNet.Model.GroupUpdate
{
	/// <summary>
	/// Добавление/редактирование/восстановление комментария к фотографии(PhotoCommentNew, PhotoCommentEdit, PhotoCommentRestore)(Comment с дополнительными полями)
	/// </summary>
	[Serializable]
	public class PhotoComment : Comment
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
				ReplyToUserId = response[key: "reply_to_user"],
				ReplyToCommentId = response[key: "reply_to_comment"],
				Attachments = response[key: "attachments"].ToReadOnlyCollectionOf<Attachment>(selector: x => x),
				Likes = response[key: "likes"],
				PhotoId = response["photo_id"],
				PhotoOwnerId = response["photo_owner_id"]
			};
		}
	}
}