using System;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Информация о участнике сообщества (группы).
	/// См. описание http://vk.com/dev/fields_groups
	/// </summary>
	[Serializable]
	public class GroupMember
	{
	#region Методы

		/// <summary>
		/// Десериализовать из Json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static GroupMember FromJson(VkResponse response)
		{
			var group = new GroupMember
			{
					UserId = response[key: "user_id"]
					, Member = response[key: "member"]
					, Request = response[key: "request"]
					, Invitation = response[key: "invitation"]
			};

			return group;
		}

	#endregion

	#region Стандартные поля

		/// <summary>
		/// Идентификатор пользователя ВК.
		/// </summary>
		public ulong? UserId { get; set; }

		/// <summary>
		/// Является ли пользователь участником сообщества;
		/// </summary>
		public bool Member { get; set; }

		/// <summary>
		/// Есть ли непринятая заявка от пользователя на вступление в группу (такую заявку
		/// можно отозвать методом
		/// groups.leave).
		/// </summary>
		public bool? Request { get; set; }

		/// <summary>
		/// Приглашён ли пользователь в группу или встречу.
		/// </summary>
		public bool? Invitation { get; set; }

	#endregion
	}
}