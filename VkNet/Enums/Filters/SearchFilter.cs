using System;

namespace VkNet.Enums.Filters
{
	/// <summary>
	/// </summary>
	[Serializable]
	public class SearchFilter : MultivaluedFilter<SearchFilter>
	{
		/// <summary>
		/// друзья пользователя
		/// </summary>
		public static readonly SearchFilter Friends = RegisterPossibleValue(value: "friends");

		/// <summary>
		/// подписки пользователя
		/// </summary>
		public static readonly SearchFilter Idols = RegisterPossibleValue(value: "idols");

		/// <summary>
		/// публичные страницы, на которые подписан пользователь
		/// </summary>
		public static readonly SearchFilter Publics = RegisterPossibleValue(value: "publics");

		/// <summary>
		/// группы пользователя
		/// </summary>
		public static readonly SearchFilter Groups = RegisterPossibleValue(value: "groups");

		/// <summary>
		/// встречи пользователя
		/// </summary>
		public static readonly SearchFilter Events = RegisterPossibleValue(value: "events");

		/// <summary>
		/// люди, у которых есть общие друзья с текущим пользователем (этот фильтр
		/// позволяет получить не всех пользователей,
		/// имеющих общих друзей).
		/// </summary>
		public static readonly SearchFilter MutualFriends = RegisterPossibleValue(value: "mutual_friends");
	}
}