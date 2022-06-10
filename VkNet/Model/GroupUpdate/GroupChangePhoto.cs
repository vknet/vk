using System;
using VkNet.Model.Attachments;
using VkNet.Utils;

namespace VkNet.Model.GroupUpdate
{
	/// <summary>
	/// Изменение главного фото
	/// </summary>
	[Serializable]
	public class GroupChangePhoto : IGroupUpdate
	{
		/// <summary>
		/// Идентификатор пользователя, который внес изменения
		/// </summary>
		public long? UserId { get; set; }

		/// <summary>
		/// Фотография
		/// </summary>
		public Photo Photo { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		public static GroupChangePhoto FromJson(VkResponse response)
		{
			return new GroupChangePhoto
			{
				UserId = response["user_id"],
				Photo = response["photo"]
			};
		}
	}
}