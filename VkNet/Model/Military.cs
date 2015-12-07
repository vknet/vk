using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Информация о военной службе пользователя.
	/// </summary>
	public class Military
	{
		/// <summary>
		/// Номер части.
		/// </summary>
		public string Unit;

		/// <summary>
		/// Идентификатор части в базе данных.
		/// </summary>
		public ulong? UnitId;

		/// <summary>
		/// Идентификатор страны, в которой находится часть.
		/// </summary>
		public long? CountryId;

		/// <summary>
		/// Год начала службы.
		/// </summary>
		public int? From;

		/// <summary>
		/// Год окончания службы.
		/// </summary>
		public int? Until;

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		internal static Military FromJson(VkResponse response)
		{
			var military = new Military
			{
				Unit = response["unit"],
				UnitId = response["unit_id"],
				CountryId = response["country_id"],
				From = response["from"],
				Until = response["until"]
			};

			return military;
		}
	}
}