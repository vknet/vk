using System;
using VkNet.Enums;

namespace VkNet.Model.Results.Notifications
{
	/// <summary>
	/// Ошибка отправки уведомления
	/// </summary>
	[Serializable]
	public class NotificationsSendMessageError
	{
		/// <summary>
		/// Код ошибки
		/// </summary>
		public NotificationsSendMessageCode Code { get; set; }

		/// <summary>
		/// Описание ошибки
		/// </summary>
		public string Description { get; set; }
	}
}