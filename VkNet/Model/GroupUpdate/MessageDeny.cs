using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Новый запрет сообщений от сообщества (<c>MessageDeny</c>)
/// </summary>
[Serializable]
public class MessageDeny : IGroupUpdate
{
	/// <summary>
	/// Идентификатор пользователя
	/// </summary>
	[JsonProperty("user_id")]
	public long? UserId { get; set; }
}