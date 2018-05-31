using System;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Информация о карьере пользователя.
	/// </summary>
	[Serializable]
	public class Career
	{
		/// <summary>
		/// Идентификатор сообщества (если доступно, иначе company).
		/// </summary>
		public long? GroupId { get; set; }

		/// <summary>
		/// Название организации (если доступно, иначе group_id).
		/// </summary>
		public string Company { get; set; }

		/// <summary>
		/// Идентификатор страны.
		/// </summary>
		public long? CountryId { get; set; }

		/// <summary>
		/// Идентификатор города (если доступно, иначе city_name).
		/// </summary>
		public long? CityId { get; set; }

		/// <summary>
		/// Название города (если доступно, иначе city_id).
		/// </summary>
		public string CityName { get; set; }

		/// <summary>
		/// Год начала работы.
		/// </summary>
		public int? From { get; set; }

		/// <summary>
		/// Год окончания работы.
		/// </summary>
		public ulong? Until { get; set; }

		/// <summary>
		/// Должность.
		/// </summary>
		public string Position { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static Career FromJson(VkResponse response)
		{
			var career = new Career
			{
					GroupId = response[key: "group_id"]
					, Company = response[key: "company"]
					, CountryId = response[key: "country_id"]
					, CityId = response[key: "city_id"]
					, CityName = response[key: "city_name"]
					, From = response[key: "from"]
					, Until = response[key: "until"]
					, Position = response[key: "position"]
			};

			return career;
		}
	}
}