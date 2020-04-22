using System;
using VkNet.Utils;

namespace VkNet.Model.GroupUpdate
{
	/// <summary>
	/// Новый запрет сообщений от сообщества (<c>MessageDeny</c>)
	/// </summary>
	[Serializable]
	public class MessageDeny
	{
		/// <summary>
		/// Идентификатор пользователя
		/// </summary>
		public long? UserId { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		public static MessageDeny FromJson(VkResponse response)
		{
			return new MessageDeny { UserId = response["user_id"] };
		}
	}
}