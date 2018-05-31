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
		public static readonly CountersFilter Friends = RegisterPossibleValue(value: "friends");

		/// <summary>
		/// Предлагаемые друзья
		/// </summary>
		public static readonly CountersFilter FriendsSuggestions = RegisterPossibleValue(value: "friends_suggestions");

		/// <summary>
		/// Количество непрочитанных сообщений
		/// </summary>
		public static readonly CountersFilter Messages = RegisterPossibleValue(value: "messages");

		/// <summary>
		/// Количество фото
		/// </summary>
		public static readonly CountersFilter Photos = RegisterPossibleValue(value: "photos");

		/// <summary>
		/// Количество видео
		/// </summary>
		public static readonly CountersFilter Videos = RegisterPossibleValue(value: "videos");

		/// <summary>
		/// Количество подарков
		/// </summary>
		public static readonly CountersFilter Gifts = RegisterPossibleValue(value: "gifts");

		/// <summary>
		/// Количество событий
		/// </summary>
		public static readonly CountersFilter Events = RegisterPossibleValue(value: "events");

		/// <summary>
		/// Количество групп
		/// </summary>
		public static readonly CountersFilter Groups = RegisterPossibleValue(value: "groups");

		/// <summary>
		/// Количество уведомлений
		/// </summary>
		public static readonly CountersFilter Notifications = RegisterPossibleValue(value: "notifications");

		/// <summary>
		/// Количество уведомлений
		/// </summary>
		public static readonly CountersFilter Sdk = RegisterPossibleValue(value: "sdk");

		/// <summary>
		/// Количество уведомлений
		/// </summary>
		public static readonly CountersFilter AppRequests = RegisterPossibleValue(value: "app_requests");

		/// <summary>
		/// Все фильтры
		/// </summary>
		public static readonly CountersFilter All =
				Friends|FriendsSuggestions|Messages|Photos|Videos|Gifts|Events|Groups|Notifications|Sdk|AppRequests;
	}
}