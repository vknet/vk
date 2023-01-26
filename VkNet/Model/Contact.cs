using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Контакты группы
/// </summary>
[Serializable]
public class Contact
{
	/// <summary>
	/// Идентификатор пользователя.
	/// </summary>
	[JsonProperty("user_id")]
	public long? UserId { get; set; }

	/// <summary>
	/// Должность.
	/// </summary>
	[JsonProperty("desc")]
	public string Description { get; set; }

	/// <summary>
	/// Электронная почта.
	/// </summary>
	[JsonProperty("email")]
	public string Email { get; set; }

	/// <summary>
	/// Телефон.
	/// </summary>
	[JsonProperty("phone")]
	public string Phone { get; set; }
}