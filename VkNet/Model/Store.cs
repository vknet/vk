using System;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Магазин.
	/// </summary>
	[Serializable]
	public class Store
	{
		/// <summary>
		/// Идентификатор магазина;.
		/// </summary>
		public long? Id { get; set; }

		/// <summary>
		/// Название магазина;.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static Store FromJson(VkResponse response)
		{
			var store = new Store
			{
					Id = response[key: "id"]
					, Name = response[key: "name"]
			};

			return store;
		}
	}
}