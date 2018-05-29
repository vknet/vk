using System;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Информация о стране.
	/// </summary>
	[Serializable]
	public class Country
	{
		/// <summary>
		/// Идентификатор страны.
		/// </summary>
		public long? Id { get; set; }

		/// <summary>
		/// Название страны.
		/// </summary>
		public string Title { get; set; }

	#region public Methods

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static Country FromJson(VkResponse response)
		{
			var country = new Country
			{
					Id = response[key: "comment_id"] ?? response[key: "cid"] ?? response[key: "id"]
					, Title = response[key: "title"] ?? response[key: "name"]
			};

			return country;
		}

	#endregion
	}
}