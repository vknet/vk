using System;
using VkNet.Utils;

namespace VkNet.Model.GroupUpdate
{
	/// <summary>
	/// Удаление комментария к видео(VideoCommentDelete)
	/// </summary>
	[Serializable]
	public class VideoCommentDelete
	{
		/// <summary>
		/// Идентификатор комментария
		/// </summary>
		public ulong? Id { get; set; }

		/// <summary>
		/// Идентификатор видео
		/// </summary>
		public long? VideoId { get; set; }

		/// <summary>
		/// Идентификатор владельца видео
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
		public static VideoCommentDelete FromJson(VkResponse response)
		{
			return new VideoCommentDelete
			{
				Id = response["id"],
				VideoId = response["video_id"],
				OwnerId = response["owner_id"],
				UserId = response["user_id"],
				DeleterId = response["deleter_id"]
			};
		}
	}
}