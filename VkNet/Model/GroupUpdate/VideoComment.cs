using System;
using VkNet.Model.Attachments;
using VkNet.Utils;

namespace VkNet.Model.GroupUpdate
{
	/// <summary>
	/// Добавление/редактирование/восстановление комментария к видео
	/// (<c>VideoCommentNew</c>, <c>VideoCommentEdit</c>, <c>VideoCommentRestore</c>)
	/// (<c>Comment</c> с дополнительными полями)
	/// </summary>
	[Serializable]
	public class VideoComment : Comment, IGroupUpdate
	{
		/// <summary>
		/// Идентификатор видеозаписи
		/// </summary>
		public long? VideoId { get; set; }

		/// <summary>
		/// Идентификатор владельца видеозаписи
		/// </summary>
		public long? VideoOwnerId { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		public new static VideoComment FromJson(VkResponse response)
		{
			return new VideoComment
			{
				Id = response[key: "id"],
				FromId = response[key: "from_id"],
				Date = response[key: "date"],
				Text = response[key: "text"],
				ReplyToUser = response[key: "reply_to_user"],
				ReplyToComment = response[key: "reply_to_comment"],
				Attachments = response[key: "attachments"].ToReadOnlyCollectionOf<Attachment>(selector: x => x),
				Likes = response[key: "likes"],
				VideoId = response["video_id"],
				VideoOwnerId = response["video_owner_id"]
			};
		}
	}
}