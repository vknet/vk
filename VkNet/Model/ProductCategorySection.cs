using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Секция катеогории товара
	/// </summary>
	public class ProductCategorySection
	{
		/// <summary>
		/// Идентификатор
		/// </summary>
		public long? Id { get; set; }

		/// <summary>
		/// Название секции
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		internal static ProductCategorySection FromJson(VkResponse response)
		{
			var product = new ProductCategorySection
			{
				Id = response["id"],
				Name = response["name"]
			};

			return product;
		}
	}
}