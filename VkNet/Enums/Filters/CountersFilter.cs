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
		public static readonly CountersFilter Friends = RegisterPossibleValue(1 << 0, "friends");
		/// <summary>
		/// Количество непрочитанных сообщений
		/// </summary>
		public static readonly CountersFilter Messages = RegisterPossibleValue(1 << 1, "messages");
		/// <summary>
		/// Количество фото
		/// </summary>
		public static readonly CountersFilter Photos = RegisterPossibleValue(1 << 2, "photos");
		/// <summary>
		/// Количество видео
		/// </summary>
		public static readonly CountersFilter Videos = RegisterPossibleValue(1 << 3, "videos");
		/// <summary>
		/// Количество заметок
		/// </summary>
		public static readonly CountersFilter Notes = RegisterPossibleValue(1 << 4, "notes");
		/// <summary>
		/// Количество подарков
		/// </summary>
		public static readonly CountersFilter Gifts = RegisterPossibleValue(1 << 5, "gifts");
		/// <summary>
		/// Количество событий
		/// </summary>
		public static readonly CountersFilter Events = RegisterPossibleValue(1 << 6, "events");
		/// <summary>
		/// Количество групп
		/// </summary>
		public static readonly CountersFilter Groups = RegisterPossibleValue(1 << 7, "groups");
		/// <summary>
		/// Количество уведомлений
		/// </summary>
		public static readonly CountersFilter Notifications = RegisterPossibleValue(1 << 8, "notifications");

		/// <summary>
		/// Все фильтры
		/// </summary>
		public static readonly CountersFilter All = Friends | Messages | Photos | Videos
			| Notes | Gifts | Events | Groups | Notifications;

	}
}