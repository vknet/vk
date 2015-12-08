using VkNet.Utils;

namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Информация о текущем роде занятия пользователя.
	/// </summary>
	public sealed class OccupationType : SafetyEnum<OccupationType>
	{
		/// <summary>
		/// Работа.
		/// </summary>
		public static readonly OccupationType Work = RegisterPossibleValue("work");

		/// <summary>
		/// Школа.
		/// </summary>
		public static readonly OccupationType School = RegisterPossibleValue("school");

		/// <summary>
		/// ВУЗ.
		/// </summary>
		public static readonly OccupationType University = RegisterPossibleValue("university");

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		internal static OccupationType FromJson(VkResponse response)
		{
			switch (response.ToString())
			{
				case "work":
					{
						return Work;
					}
				case "school":
					{
						return School;
					}
				case "university":
					{
						return University;
					}
				default:
					{
						return null;
					}
			}
		}
	}
}