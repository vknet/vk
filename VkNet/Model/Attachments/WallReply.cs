using System;
using System.Runtime.Serialization;
using VkNet.Utils;

namespace VkNet.Model.Attachments
{
	/// <summary>
	/// Комментарий к записи на стене.
	/// </summary>
	[Serializable]
	public class WallReply : MediaAttachment
    {
		/// <summary>
		/// Комментарий к записи на стене.
		/// </summary>
		static WallReply()
        {
            RegisterType(typeof(WallReply), "wall_reply");
        }

		/// <summary>
		/// Идентификатор автора комментария.
		/// </summary>
		public long? FromId { get; set; }

		/// <summary>
		/// Дата создания комментария в формате unixtime.
		/// </summary>
		public DateTime? Date { get; set; }

		/// <summary>
		/// Текст комментария.
		/// </summary>
		public string Text { get; set; }

		/// <summary>
		/// Информация о лайках к комментарию.
		/// </summary>
		public Likes Likes { get; set; }

		/// <summary>
		/// Идентификатор пользователя, в ответ которому был оставлен комментарий;
		/// </summary>
		public long? ReplyToUId { get; set; }

		/// <summary>
		/// Идентификатор комментария, в ответ на который был оставлен текущий.
		/// </summary>
		public long? ReplyToCId { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
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
	}
}
