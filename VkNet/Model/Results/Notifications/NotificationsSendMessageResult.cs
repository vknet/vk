using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Результат метода Notifications.SendMessage
/// </summary>
[Serializable]
public class NotificationsSendMessageResult
{
	/// <summary>
	/// Идентификатор пользователя
	/// </summary>
	[JsonProperty("user_id")]
	public ulong UserId { get; set; }

	/// <summary>
	/// Статус уведомления
	/// </summary>
	[JsonProperty("status")]
	public bool Status { get; set; }

	/// <summary>
	/// Ошибка отправки уведомления
	/// </summary>
	[JsonProperty("error")]
	public NotificationsSendMessageError Error { get; set; }
}