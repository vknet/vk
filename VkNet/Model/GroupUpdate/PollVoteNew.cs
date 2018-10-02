using System;
using VkNet.Utils;

namespace VkNet.Model.GroupUpdate
{
	/// <summary>
	/// Добавление голоса в публичном опросе
	/// </summary>
	[Serializable]
	public class PollVoteNew
	{
		/// <summary>
		/// Идентификатор пользователя
		/// </summary>
		public long? UserId { get; set; }

		/// <summary>
		/// Идентификатор опроса
		/// </summary>
		public long? PollId { get; set; }

		/// <summary>
		/// Идентификатор варианта ответа
		/// </summary>
		public long? OptionId { get; set; }

		/// <summary>
		/// Идентификатор владельца опроса
		/// </summary>
		public long? OwnerId { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		public static PollVoteNew FromJson(VkResponse response)
		{
			return new PollVoteNew
			{
				UserId = response["user_id"],
				PollId = response["poll_id"],
				OptionId = response["option_id"],
				OwnerId = response["owner_id"]
			};
		}
	}
}