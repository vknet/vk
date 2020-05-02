using System;
using System.Collections.ObjectModel;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Результат поиск пользователей по другим сервисам.
	/// </summary>
	[Serializable]
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
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static LookupContactsResult FromJson(VkResponse response)
		{
			return new LookupContactsResult
			{
					FoundList = response[key: "found"].ToReadOnlyCollectionOf<User>(selector: x => x)
					, Other = response[key: "other"].ToReadOnlyCollectionOf<LookupContactsOther>(selector: x => x)
			};
		}
	}
}