using VkNet.Utils;

namespace VkNet.Enums
{
	/// <summary>
	/// Код ошибки при отправке уведомления
	/// </summary>
	public enum NotificationsSendMessageCode
	{
		/// <summary>
		/// Уведомления приложения отключены
		/// </summary>
		NotificationsOff = 1,

		/// <summary>
		/// Отправлено слишком много уведомлений за последний час
		/// </summary>
		ManyNotificationsForLastHour = 2,

		/// <summary>
		/// Отправлено слишком много уведомлений за последние сутки
		/// </summary>
		ManyNotificationsForLastDay = 3,

		/// <summary>
		/// Приложение не установлено.
		/// </summary>
		[DefaultValue]
		ApplicationNotInstalled = 3,
	}
}