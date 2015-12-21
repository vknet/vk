using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Информация о продукте.
	/// </summary>
	public class Product
	{
		/// <summary>
		/// Цена
		/// </summary>
		public Price Price { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		internal static Product FromJson(VkResponse response)
		{
			var product = new Product
			{
				Price = response["price"]
			};

			return product;
		}
	}
}