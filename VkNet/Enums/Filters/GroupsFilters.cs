namespace VkNet.Enums.Filters
{
	/// <summary>
	/// Фильтры сообществ пользователя.
	/// </summary>
	public sealed class GroupsFilters : MultivaluedFilter<GroupsFilters>
	{
		/// <summary>
		/// Вернуть все сообщества, в которых пользователь является администратором.
		/// </summary>
		public static readonly GroupsFilters Administrator = RegisterPossibleValue(mask: 1 << 0, value: "admin");

		/// <summary>
		/// Вернуть все сообщества, в которых пользователь является администратором или
		/// редактором.
		/// </summary>
		public static readonly GroupsFilters Editor = RegisterPossibleValue(mask: 1 << 1, value: "editor");

		/// <summary>
		/// Вернуть все сообщества, в которых пользователь является администратором,
		/// редактором или модератором.
		/// </summary>
		public static readonly GroupsFilters Moderator = RegisterPossibleValue(mask: 1 << 2, value: "moder");

		/// <summary>
		/// Вернуть все группы, в которые входит пользователь.
		/// </summary>
		public static readonly GroupsFilters Groups = RegisterPossibleValue(mask: 1 << 3, value: "groups");

		/// <summary>
		/// Вернуть все публичные страницы пользователя ???
		/// </summary>
		public static readonly GroupsFilters Publics = RegisterPossibleValue(mask: 1 << 4, value: "publics");

		/// <summary>
		/// Вернуть все события, в которых участвует пользователь.
		/// </summary>
		public static readonly GroupsFilters Events = RegisterPossibleValue(mask: 1 << 5, value: "events");

		/// <summary>
		/// Вернуть все сообщества, в которых задействован пользователь.
		/// </summary>
		public static readonly GroupsFilters All = Administrator|Editor|Moderator|Groups|Publics|Events;
	}
}