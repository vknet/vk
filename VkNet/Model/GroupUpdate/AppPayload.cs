using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Добавление пользователя в чёрный список
/// </summary>
[Serializable]
public class AppPayload : IGroupUpdate
{
	/// <summary>
	/// Идентификатор пользователя
	/// </summary>
	[JsonProperty("user_id")]
	public long? UserId { get; set; }

	/// <summary>
	/// Идентификатор приложения, из которого было отправлено событие.
	/// </summary>
	[JsonProperty("app_id")]
	public long? AppId { get; set; }

	/// <summary>
	/// Идентификатор сообщества, в которое отправлено уведомление
	/// </summary>
	[JsonProperty("group_id ")]
	public long? GroupId { get; set; }

	/// <summary>
	/// блокировке
	/// </summary>
	[JsonProperty("payload")]
	public string Payload { get; set; }
}