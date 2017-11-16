using System.Collections.Generic;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Ответ на запрос метода groups.getCatalogInfo
	/// </summary>
	public class GroupsCatalogInfo
	{
		/// <summary>
		/// Признак доступности каталога для пользователя.
		/// </summary>
		public bool Enabled { get; set; }

		/// <summary>
		/// Список категорий.
		/// </summary>
		public IEnumerable<CategoryGroup> Categories;

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		public static GroupsCatalogInfo FromJson(VkResponse response)
		{
			var result = new GroupsCatalogInfo
			{
				Enabled = response["enabled"],
				Categories = response["categories"].ToReadOnlyCollectionOf<CategoryGroup>(o => o)
			};

			return result;
		}
	}
}