using System;
using VkNet.Utils;

namespace VkNet.Model.GroupUpdate
{
	/// <summary>
	/// Удаление/выход участника из сообщества
	/// </summary>
	[Serializable]
	public class GroupLeave : IGroupUpdate
	{
		/// <summary>
		/// Идентификатор пользователя
		/// </summary>
		public long? UserId { get; set; }

		/// <summary>
		/// Самостоятельный ли был выход
		/// </summary>
		public bool? IsSelf { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		public static GroupLeave FromJson(VkResponse response)
		{
			return new GroupLeave
			{
				UserId = response["user_id"],
				IsSelf = response["self"]
			};
		}

		/// <summary>
		/// Преобразование класса <see cref="GroupLeave" /> в <see cref="VkParameters" />
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> Результат преобразования в <see cref="GroupLeave" /> </returns>
		public static implicit operator GroupLeave(VkResponse response)
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