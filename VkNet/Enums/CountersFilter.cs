using VkNet.Utils;

namespace VkNet.Enums
{
	/// <summary>
	/// Фильтры счетчиков
	/// </summary>
	public class CountersFilter : VkFilter
	{
		/// <summary>
		/// Количество заявок в друзья
		/// </summary>
		public static readonly CountersFilter Friends = new CountersFilter(1 << 0, "friends");
		/// <summary>
		/// Количество непрочитанных сообщений
		/// </summary>
		public static readonly CountersFilter Messages = new CountersFilter(1 << 1, "messages");
		/// <summary>
		/// Количество фото
		/// </summary>
		public static readonly CountersFilter Photos = new CountersFilter(1 << 2, "photos");
		/// <summary>
		/// Количество видео
		/// </summary>
		public static readonly CountersFilter Videos = new CountersFilter(1 << 3, "videos");
		/// <summary>
		/// Количество заметок
		/// </summary>
		public static readonly CountersFilter Notes = new CountersFilter(1 << 4, "notes");
		/// <summary>
		/// Количество подарков
		/// </summary>
		public static readonly CountersFilter Gifts = new CountersFilter(1 << 5, "gifts");
		/// <summary>
		/// Количество событий
		/// </summary>
		public static readonly CountersFilter Events = new CountersFilter(1 << 6, "events");
		/// <summary>
		/// Количество групп
		/// </summary>
		public static readonly CountersFilter Groups = new CountersFilter(1 << 7, "groups");
		/// <summary>
		/// Количество уведомлений
		/// </summary>
		public static readonly CountersFilter Notifications = new CountersFilter(1 << 8, "notifications");
		
		/// <summary>
		/// Все фильтры
		/// </summary>
		public static readonly CountersFilter All = Friends | Messages | Photos | Videos
			| Notes | Gifts | Events | Groups | Notifications;

		private CountersFilter(long value, string name)
			: base(value, name)
		{

		}

		private CountersFilter(CountersFilter left, CountersFilter right)
			: base(left, right)
		{

		}

		/// <summary>
		/// Оператор объединения полей профиля.
		/// </summary>
		/// <param name="left">Левое поле выражения объединения.</param>
		/// <param name="right">Правое поле выражения объединения.</param>
		/// <returns>Результат объединения.</returns>
		public static CountersFilter operator |(CountersFilter left, CountersFilter right)
		{
			return new CountersFilter(left, right);
		}
	}
}