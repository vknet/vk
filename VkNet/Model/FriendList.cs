﻿using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Метка в списке друзей
	/// </summary>
	public class FriendList
	{
		/// <summary>
		/// Идентификатор метки
		/// </summary>
		public long Id { get; set; }

		/// <summary>
		/// Название метки
		/// </summary>
		public string Name { get; set; }

		#region Internal Methods
		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		internal static FriendList FromJson(VkResponse response)
		{
			var list = new FriendList
			{
				Id = response["lid"],
				Name = response["name"]
			};

			return list;
		}

		#endregion
	}
}