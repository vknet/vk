using System;
using VkNet.Utils;

namespace VkNet.Model.GroupUpdate
{
	/// <summary>
	/// Новый запрет сообщений от сообщества (<c>MessageDeny</c>)
	/// </summary>
	[Serializable]
	public class MessageDeny : IGroupUpdate
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

		/// <summary>
		/// Преобразование класса <see cref="MessageDeny" /> в <see cref="VkParameters" />
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> Результат преобразования в <see cref="MessageDeny" /> </returns>
		public static implicit operator MessageDeny(VkResponse response)
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