using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model;

/// <summary>
/// Результат метода auth.confirm
/// </summary>
[Serializable]
public class AuthConfirmResult
{
	/// <summary>
	/// Успешно.
	/// </summary>
	[JsonProperty("success")]
	public bool Success { get; set; }

	/// <summary>
	/// Идентификатор пользователя.
	/// </summary>
	[JsonProperty("uid")]
	public long UserId { get; set; }
}