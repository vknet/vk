namespace VkNet.Enums.Filters
{
	/// <summary>
	/// Фильтры счетчиков
	/// </summary>
	public sealed class CountersFilter : MultivaluedFilter<CountersFilter>
	{
        /// <summary>
        /// Количество заявок в друзья
        /// </summary>
        public static readonly CountersFilter Friends = RegisterPossibleValue("friends");

        /// <summary>
        /// Предлагаемые друзья
        /// </summary>
        public static readonly CountersFilter FriendsSuggestions = RegisterPossibleValue("friends_suggestions");

        /// <summary>
        /// Количество непрочитанных сообщений
        /// </summary>
        public static readonly CountersFilter Messages = RegisterPossibleValue("messages");

        /// <summary>
        /// Количество фото
        /// </summary>
        public static readonly CountersFilter Photos = RegisterPossibleValue("photos");

        /// <summary>
        /// Количество видео
        /// </summary>
        public static readonly CountersFilter Videos = RegisterPossibleValue("videos");

        /// <summary>
        /// Количество подарков
        /// </summary>
        public static readonly CountersFilter Gifts = RegisterPossibleValue("gifts");

        /// <summary>
        /// Количество событий
        /// </summary>
        public static readonly CountersFilter Events = RegisterPossibleValue("events");

        /// <summary>
        /// Количество групп
        /// </summary>
        public static readonly CountersFilter Groups = RegisterPossibleValue("groups");

        /// <summary>
        /// Количество уведомлений
        /// </summary>
        public static readonly CountersFilter Notifications = RegisterPossibleValue("notifications");

        /// <summary>
        /// Количество уведомлений
        /// </summary>
        public static readonly CountersFilter Sdk = RegisterPossibleValue("sdk");

        /// <summary>
        /// Количество уведомлений
        /// </summary>
        public static readonly CountersFilter AppRequests = RegisterPossibleValue("app_requests");

        /// <summary>
        /// Все фильтры
        /// </summary>
        public static readonly CountersFilter All = Friends | FriendsSuggestions | Messages | Photos | Videos | Gifts | Events | Groups | Notifications | Sdk | AppRequests;
    }
}