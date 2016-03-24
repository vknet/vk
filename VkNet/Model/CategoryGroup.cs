using System.Collections.Generic;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Категории для каталога сообществ
	/// </summary>
	public class CategoryGroup : IVkModel
	{
		/// <summary>
		/// Идентификатор.
		/// </summary>
		public long Id { get; set; }

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
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		internal static CategoryGroup FromJson(VkResponse response)
		{
			return new CategoryGroup
			{
				Id = response["id"],
				Name = response["name"],
				Subcategories = response["subcategories"].ToReadOnlyCollectionOf<CategoryGroup>(o => o),
				PageCount = response["page_count"],
				PagePreviews = response["page_previews"].ToReadOnlyCollectionOf<Group>(o => o)
			};
		}

		/// <summary>
		/// Преобразовать из JSON
		/// </summary>
		/// <param name="response">Ответ от сервера.</param>
		/// <returns></returns>
		IVkModel IVkModel.FromJson(VkResponse response)
		{
			return FromJson(response);
		}
	}
}