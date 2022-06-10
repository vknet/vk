using System;
using VkNet.Model.Attachments;
using VkNet.Utils;

namespace VkNet.Model.GroupUpdate
{
	/// <summary>
	/// Добавление/редактирование/восстановление комментария в обсуждении(<c>BoardPostNew</c>, <c>BoardPostEdit</c>, <c>BoardPostRestore</c>)
	/// (<c>CommentBoard</c> с дополнительными полями)
	/// </summary>
	[Serializable]
	public class BoardPost : CommentBoard, IGroupUpdate
	{
		/// <summary>
		/// Идентификатор обсуждения
		/// </summary>
		public ulong? TopicId { get; set; }

		/// <summary>
		/// Идентификатор владельца обсуждения
		/// </summary>
		public long? TopicOwnerId { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		public new static BoardPost FromJson(VkResponse response)
		{
			return new BoardPost
			{
				Id = response[key: "id"],
				FromId = response[key: "from_id"],
				Date = response[key: "date"],
				Text = response[key: "text"],
				Likes = response[key: "likes"],
				Attachments = response[key: "attachments"].ToReadOnlyCollectionOf<Attachment>(selector: x => x),
				TopicId = response["topic_id"],
				TopicOwnerId = response["topic_owner_id"]
			};
		}

		/// <summary>
		/// Преобразование класса <see cref="BoardPost" /> в <see cref="VkParameters" />
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> Результат преобразования в <see cref="BoardPost" /> </returns>
		public static implicit operator BoardPost(VkResponse response)
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