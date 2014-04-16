namespace VkNet.Enums.Filters
{
	/// <summary>
    /// Фильтры сообществ пользователя.
    /// </summary>
    public sealed class GroupsFilters : Filter<GroupsFilters>
    {
        /// <summary>
        /// Вернуть все сообщества, в которых пользователь является администратором.
        /// </summary>
        public static readonly GroupsFilters Administrator = RegisterPossibleValue(1 << 0, "admin");

        /// <summary>
        /// Вернуть все сообщества, в которых пользователь является администратором или редактором.
        /// </summary>
        public static readonly GroupsFilters Editor = RegisterPossibleValue(1 << 1, "editor");

        /// <summary>
        /// Вернуть все сообщества, в которых пользователь является администратором, редактором или модератором.
        /// </summary>
        public static readonly GroupsFilters Moderator = RegisterPossibleValue(1 << 2, "moder");

        /// <summary>
        /// Вернуть все группы, в которые входит пользователь.
        /// </summary>
        public static readonly GroupsFilters Groups = RegisterPossibleValue(1 << 3, "groups");

        /// <summary>
        /// Вернуть все публичные страницы пользователя ???
        /// </summary>
        public static readonly GroupsFilters Publics = RegisterPossibleValue(1 << 4, "publics");

        /// <summary>
        /// Вернуть все события, в которых участвует пользователь.
        /// </summary>
        public static readonly GroupsFilters Events = RegisterPossibleValue(1 << 5, "events");

        /// <summary>
        /// Вернуть все сообщества, в которых задействован пользователь.
        /// </summary>
        public static readonly GroupsFilters All = Administrator | Editor | Moderator | Groups | Publics | Events;

    }
}