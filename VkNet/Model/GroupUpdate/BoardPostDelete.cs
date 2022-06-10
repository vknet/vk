using System;
using VkNet.Utils;

namespace VkNet.Model.GroupUpdate
{
	/// <summary>
	/// Удаление комментария в обсуждении (<c>BoardPostDelete</c>)
	/// </summary>
	[Serializable]
	public class BoardPostDelete : IGroupUpdate
	{
		/// <summary>
		/// Идентификатор комментария
		/// </summary>
		public ulong? Id { get; set; }

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
		public static BoardPostDelete FromJson(VkResponse response)
		{
			return new BoardPostDelete
			{
				Id = response["id"],
				TopicId = response["topic_id"],
				TopicOwnerId = response["topic_owner_id"],
			};
		}
	}
}