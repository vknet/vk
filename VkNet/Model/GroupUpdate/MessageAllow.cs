using System;
using VkNet.Utils;

namespace VkNet.Model.GroupUpdate
{
	/// <summary>
	/// Подписка на сообщения от сообщества (<c>MessageAllow</c>, ваш капитан!)
	/// </summary>
	[Serializable]
	public class MessageAllow : IGroupUpdate
	{
		/// <summary>
		/// Идентификатор пользователя
		/// </summary>
		public long? UserId { get; set; }

		/// <summary>
		/// Параметр, переданный в методе <c>messages.allowMessagesFromGroup</c>
		/// </summary>
		public string Key { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		public static MessageAllow FromJson(VkResponse response)
		{
			return new MessageAllow
			{
				UserId = response["user_id"],
				Key = response["key"]
			};
		}
	}
}