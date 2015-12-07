using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Информация о карьере пользователя.
	/// </summary>
	public class Career
	{
		/// <summary>
		/// Идентификатор сообщества (если доступно, иначе company).
		/// </summary>
		public long? GroupId;

		/// <summary>
		/// Название организации (если доступно, иначе group_id).
		/// </summary>
		public string Company;

		/// <summary>
		/// Идентификатор страны.
		/// </summary>
		public long CountryId;

		/// <summary>
		/// Идентификатор города (если доступно, иначе city_name).
		/// </summary>
		public long CityId;

		/// <summary>
		/// Название города (если доступно, иначе city_id).
		/// </summary>
		public string CityName;

		/// <summary>
		/// Год начала работы.
		/// </summary>
		public int From;

		/// <summary>
		/// Год окончания работы.
		/// </summary>
		public int? Until;

		/// <summary>
		/// Должность.
		/// </summary>
		public string Position;

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		internal static Career FromJson(VkResponse response)
		{
			var career = new Career
			{
				GroupId = response["group_id"],
				Company = response["company"],
				CountryId = response["country_id"],
				CityId = response["city_id"],
				CityName = response["city_name"],
				From = response["from"],
				Until = response["until"],
				Position = response["position"]
			};

			return career;
		}
	}
}