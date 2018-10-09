using System;
using VkNet.Utils;

namespace VkNet.Model.GroupUpdate
{
	/// <summary>
	/// Удаление пользователя из чёрного списка
	/// </summary>
	[Serializable]
	public class UserUnblock
	{
		/// <summary>
		/// Идентификатор пользователя
		/// </summary>
		public long? UserId { get; set; }

		/// <summary>
		/// Идентификатор администратора, который убрал пользователя из чёрного списка
		/// </summary>
		public long? AdminId { get; set; }

		/// <summary>
		/// Была ли разблокировка по окончанию блокировки
		/// </summary>
		public bool? ByEndDate { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		public static UserUnblock FromJson(VkResponse response)
		{
			return new UserUnblock
			{
				UserId = response["user_id"],
				AdminId = response["admin_id"],
				ByEndDate = response["by_end_date"],
			};
		}
	}
}