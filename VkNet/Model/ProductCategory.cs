using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Категория товара.
	/// </summary>
	public class ProductCategory
	{
		/// <summary>
		/// Идентификатор
		/// </summary>
		public long? Id { get; set; }

		/// <summary>
		/// Название категории
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Секция
		/// </summary>
		public ProductCategorySection Section;

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		internal static ProductCategory FromJson(VkResponse response)
		{
			var product = new ProductCategory
			{
				Id = response["id"],
				Name = response["name"],
				Section = response["section"]
			};

			return product;
		}
	}
}