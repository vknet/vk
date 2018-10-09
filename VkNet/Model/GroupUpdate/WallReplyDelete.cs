using System;
using VkNet.Utils;

namespace VkNet.Model.GroupUpdate
{
	/// <summary>
	/// Удаление комментария к записи(WallReplyDelete)
	/// </summary>
	[Serializable]
	public class WallReplyDelete
	{
		/// <summary>
		/// Идентификатор комментария
		/// </summary>
		public ulong? Id { get; set; }

		/// <summary>
		/// Идентификатор записи, к которой был оставлен комментарий
		/// </summary>
		public long? PostId { get; set; }

		/// <summary>
		/// Идентификатор владельца стены
		/// </summary>
		public long? OwnerId { get; set; }

		/// <summary>
		/// Идентификатор автора комментария
		/// </summary>
		public long? UserId { get; set; }

		/// <summary>
		/// Идентификатор пользователя, который удалил комментарий
		/// </summary>
		public long? DeleterId { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		public static WallReplyDelete FromJson(VkResponse response)
		{
			return new WallReplyDelete
			{
				Id = response["id"],
				PostId = response["post_id"],
				OwnerId = response["owner_id"],
				UserId = response["user_id"],
				DeleterId = response["deleter_id"]
			};
		}
	}
}