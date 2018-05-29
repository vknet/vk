using System;

namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Тип объекта поиска
	/// </summary>
	[Serializable]
	public class SearchResultType : SafetyEnum<SearchResultType>
	{
		/// <summary>
		/// Сообщество
		/// </summary>
		public static readonly SearchResultType Group = RegisterPossibleValue(value: "group");

		/// <summary>
		/// Профиль
		/// </summary>
		public static readonly SearchResultType Profile = RegisterPossibleValue(value: "profile");
	}
}