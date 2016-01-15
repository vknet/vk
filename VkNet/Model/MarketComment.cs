using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Комментарий к товару
	/// </summary>
	public class MarketComment
	{
		/// <summary>
		/// Список комментариев.
		/// </summary>
		public ReadOnlyCollection<Comment> Comments { get; set; }

		/// <summary>
		/// Количество комментариев.
		/// </summary>
		public long Count { get; set; }

		/// <summary>
		/// Список пользователей.
		/// </summary>
		public ReadOnlyCollection<User> Profiles { get; set; }

		/// <summary>
		/// Список сообществ.
		/// </summary>
		public ReadOnlyCollection<Group> Groups { get; set; }
		

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		internal static MarketComment FromJson(VkResponse response)
		{
			var item = new MarketComment
			{
				Comments = response["items"].ToReadOnlyCollectionOf<Comment>(x => x),
				Count = response["count"],
				Profiles = response["profiles"].ToReadOnlyCollectionOf<User>(x => x),
				Groups = response["groups"].ToReadOnlyCollectionOf<Group>(x => x)
			};

			return item;
		}

		
	}
}