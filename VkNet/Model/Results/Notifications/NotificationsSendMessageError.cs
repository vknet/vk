using System;
using Newtonsoft.Json;
using VkNet.Enums;

namespace VkNet.Model;

/// <summary>
/// Ошибка отправки уведомления
/// </summary>
[Serializable]
public class NotificationsSendMessageError
{
	/// <summary>
	/// Код ошибки
	/// </summary>
	[JsonProperty("code")]
	public NotificationsSendMessageCode Code { get; set; }

	/// <summary>
	/// Описание ошибки
	/// </summary>
	[JsonProperty("description")]
	public string Description { get; set; }
}