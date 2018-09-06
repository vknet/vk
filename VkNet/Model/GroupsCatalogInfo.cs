using System;
using System.Collections.Generic;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Ответ на запрос метода groups.getCatalogInfo
	/// </summary>
	[Serializable]
	public class GroupsCatalogInfo
	{
		/// <summary>
		/// Список категорий.
		/// </summary>
		public IEnumerable<CategoryGroup> Categories { get; set; }

		/// <summary>
		/// Признак доступности каталога для пользователя.
		/// </summary>
		public bool Enabled { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static GroupsCatalogInfo FromJson(VkResponse response)
		{
			var result = new GroupsCatalogInfo
			{
				Enabled = response[key: "enabled"],
				Categories = response[key: "categories"].ToReadOnlyCollectionOf<CategoryGroup>(selector: o => o)
			};

			return result;
		}
	}
}