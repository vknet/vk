using System;
using Newtonsoft.Json;
using VkNet.Utils;

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

	/// <summary>
	/// Разобрать из json.
	/// </summary>
	/// <param name="response"> Ответ сервера. </param>
	/// <returns> </returns>
	public static ChatPushSettings FromJson(VkResponse response)
	{
		var result = new ChatPushSettings
		{
			PeerId = response[key: "peer_id"],
			Sound = response[key: "sound"],
			DisabledUntil = response[key: "disabled_until"]
		};

		return result;
	}
}