using System;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Город.
	/// </summary>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/database.getCities
	/// </remarks>
	[Serializable]
	public class City
	{
		/// <summary>
		/// Идентификатор города.
		/// </summary>
		public long? Id { get; set; }

		/// <summary>
		/// Название города.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Район.
		/// </summary>
		public string Area { get; set; }

		/// <summary>
		/// Область.
		/// </summary>
		public string Region { get; set; }

		/// <summary>
		/// Является ли город основным.
		/// </summary>
		public bool Important { get; set; }

	#region Inernal Methods

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static City FromJson(VkResponse response)
		{
			string id = response[key: "comment_id"] ?? response[key: "cid"] ?? response[key: "id"];

			return new City
			{
					Id = Convert.ToInt64(value: id)
					, Title = response[key: "title"] ?? response[key: "name"]
					, Area = response[key: "area"]
					, Region = response[key: "region"]
					, Important = response[key: "important"] ?? false
			};
		}

	#endregion
	}
}