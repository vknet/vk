using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Настройки уведомлений для беседы
/// </summary>
[Serializable]
public class ChatPushSettings
{
	/// <summary>
	/// Идентификатор собеседника.
	/// </summary>
	[JsonProperty("peer_id")]
	public long? PeerId { get; set; }

	/// <summary>
	/// Состояние звукового оповещения
	/// </summary>
	[JsonProperty("sound")]
	public bool? Sound { get; set; }

	/// <summary>
	/// Неизвестный параметр
	/// </summary>
	[JsonProperty("disabled_until")]
	public int? DisabledUntil { get; set; }
}