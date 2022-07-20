using System;
using VkNet.Model.Attachments;
using VkNet.Utils;

namespace VkNet.Model.GroupUpdate
{
	/// <summary>
	/// Добавление/редактирование/восстановление комментария на стене
	/// (<c>WallReplyNew</c>, <c>WallReplyEdit</c>, <c>WallReplyRestore</c>)
	/// (<c>Comment</c> с дополнительными полями)
	/// </summary>
	[Serializable]
	public class WallReply : Comment, IGroupUpdate
	{
		/// <summary>
		/// Идентификатор записи
		/// </summary>
		public long? PostId { get; set; }

		/// <summary>
		/// Идентификатор владельца записи
		/// </summary>
		public long? PostOwnerId { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		public new static WallReply FromJson(VkResponse response)
		{
			return new WallReply
			{
				Id = response[key: "id"],
				FromId = response[key: "from_id"],
				Date = response[key: "date"],
				Text = response[key: "text"],
				ReplyToUser = response[key: "reply_to_user"],
				ReplyToComment = response[key: "reply_to_comment"],
				Attachments = response[key: "attachments"].ToReadOnlyCollectionOf<Attachment>(selector: x => x),
				Likes = response[key: "likes"],
				PostId = response["post_id"],
				PostOwnerId = response["post_owner_id"]
			};
		}

		/// <summary>
		/// Преобразование класса <see cref="WallReply" /> в <see cref="VkParameters" />
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> Результат преобразования в <see cref="WallReply" /> </returns>
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
}