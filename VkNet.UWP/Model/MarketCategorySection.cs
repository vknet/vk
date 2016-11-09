using System;
using System.Runtime.Serialization;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Секция катеогории товара
	/// </summary>
	[DataContract]
	public class MarketCategorySection
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
		public static MarketCategorySection FromJson(VkResponse response)
		{
			var product = new MarketCategorySection
			{
				Id = response["id"],
				Name = response["name"]
			};

			return product;
		}
	}
}