using System;
using Newtonsoft.Json;
using VkNet.Enums.StringEnums;

namespace VkNet.Model;

/// <summary>
/// Данные о сервере
/// </summary>
[Serializable]
public class CallbackServerItem
{
	/// <summary>
	/// Идентификатор сервера
	/// </summary>
	[JsonProperty(propertyName: "id")]
	public long Id { get; set; }

	/// <summary>
	/// Название сервера
	/// </summary>
	[JsonProperty(propertyName: "title")]
	public string Title { get; set; }

	/// <summary>
	/// Идентификатор пользователя, который добавил сервер (может содержать 0)
	/// </summary>
	[JsonProperty(propertyName: "creator_id")]
	public long CreatorId { get; set; }

	/// <summary>
	/// URL сервера
	/// </summary>
	[JsonProperty(propertyName: "url")]
	public string Url { get; set; }

	/// <summary>
	/// Секретный ключ
	/// </summary>
	[JsonProperty(propertyName: "secret_key")]
	public string SecretKey { get; set; }

	/// <summary>
	/// Статус сервера
	/// </summary>
	[JsonProperty(propertyName: "status")]
	public CallbackServerStatus? Status { get; set; }
}