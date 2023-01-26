using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace VkNet.Model;

/// <summary>
/// Информация о последней активности пользователя.
/// См. описание http://vk.com/dev/messages.getLastActivity
/// </summary>
[Serializable]
public class LastActivity
{
	/// <summary>
	/// Идентификатор пользователя.
	/// </summary>
	[JsonProperty("user_id")]
	public long UserId { get; set; }

	/// <summary>
	/// Текущий статус пользователя (true - в сети, false - не в сети).
	/// </summary>
	[JsonProperty("online")]
	public bool? IsOnline { get; set; }

	/// <summary>
	/// Дата последней активности пользователя.
	/// </summary>
	[JsonProperty("time")]
	[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
	public DateTime? Time { get; set; }
}