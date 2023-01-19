using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Результат авторизаци
/// </summary>
[Serializable]
public class AuthorizationResult
{
	/// <summary>
	/// Access Token
	/// </summary>
	[JsonProperty("access_token")]
	public string AccessToken { get; set; }

	/// <summary>
	/// Время истечения токена
	/// </summary>
	[JsonProperty("expires_in")]
	public int ExpiresIn { get; set; }

	/// <summary>
	/// Идентификатор пользователя
	/// </summary>
	[JsonProperty("user_id")]
	public long UserId { get; set; }

	/// <summary>
	/// Произвольная строка, которая будет возвращена вместе с результатом авторизации.
	/// </summary>
	[JsonProperty("state")]
	public string State { get; set; }
}