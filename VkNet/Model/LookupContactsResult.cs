﻿using System.Collections.ObjectModel;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Результат поиск пользователей по другим сервисам.
	/// </summary>
	public class LookupContactsResult
	{
		/// <summary>
		/// Список объектов пользователей.
		/// </summary>
		public ReadOnlyCollection<User> FoundList { get; set; }

		/// <summary>
		/// Список контактов, которые не были найдены.
		/// </summary>
		public ReadOnlyCollection<LookupContactsOther> Other { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		internal static LookupContactsResult FromJson(VkResponse response)
		{
			return new LookupContactsResult
			{
				FoundList = response["found"].ToReadOnlyCollectionOf<User>(x => x),
				Other = response["other"].ToReadOnlyCollectionOf<LookupContactsOther>(x => x)
			};
		}
	}
}