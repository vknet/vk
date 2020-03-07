using System;
using System.Collections.Generic;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Категории для каталога сообществ
	/// </summary>
	[Serializable]
	public class AdsCategories
	{
		/// <summary>
		/// Название категории.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the subcategories.
		/// </summary>
		public IEnumerable<AdsCategories> Subcategories { get; set; }

		/// <summary>
		/// Идентификатор.
		/// </summary>
		public long Id { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static AdsCategories FromJson(VkResponse response)
		{
			return new AdsCategories
			{
				Id = response[key: "id"],
				Name = response[key: "name"],
				Subcategories = response[key: "subcategories"].ToReadOnlyCollectionOf<AdsCategories>(selector: x => x)
			};
		}
	}
}