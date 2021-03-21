using System;

namespace VkNet.Model.Results.Notifications
{
	/// <summary>
	/// Результат метода Notifications.SendMessage
	/// </summary>
	[Serializable]
	public class NotificationsSendMessageResult
	{
		/// <summary>
		/// Идентификатор пользователя
		/// </summary>
		public ulong UserId { get; set; }

		/// <summary>
		/// Статус уведомления
		/// </summary>
		public bool Status { get; set; }

		/// <summary>
		/// Ошибка отправки уведомления
		/// </summary>
		public NotificationsSendMessageError Error { get; set; }
	}
}