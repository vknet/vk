using System;
using System.Collections.Generic;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Категории для каталога сообществ
	/// </summary>
	[Serializable]
	public class CategoryGroup : IVkModel
	{
		/// <summary>
		/// Название категории.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the subcategories.
		/// </summary>
		public IEnumerable<CategoryGroup> Subcategories { get; set; }

		/// <summary>
		/// Количество сообществ в категории.
		/// </summary>
		public long? PageCount { get; set; }

		/// <summary>
		/// Массив объектов сообществ для предпросмотра.
		/// </summary>
		public IEnumerable<Group> PagePreviews { get; set; }

		/// <summary>
		/// Идентификатор.
		/// </summary>
		public long Id { get; set; }

		/// <summary>
		/// Преобразовать из JSON
		/// </summary>
		/// <param name="response"> Ответ от сервера. </param>
		/// <returns> </returns>
		IVkModel IVkModel.FromJson(VkResponse response)
		{
			return FromJson(response: response);
		}

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static CategoryGroup FromJson(VkResponse response)
		{
			return new CategoryGroup
			{
				Id = response[key: "id"],
				Name = response[key: "name"],
				Subcategories = response[key: "subcategories"].ToReadOnlyCollectionOf<CategoryGroup>(selector: o => o),
				PageCount = response[key: "page_count"],
				PagePreviews = response[key: "page_previews"].ToReadOnlyCollectionOf<Group>(selector: o => o)
			};
		}
	}
}