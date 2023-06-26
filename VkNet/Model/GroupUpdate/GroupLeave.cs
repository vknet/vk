using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Удаление/выход участника из сообщества
/// </summary>
[Serializable]
public class GroupLeave : IGroupUpdate
{
	/// <summary>
	/// Идентификатор пользователя
	/// </summary>
	[JsonProperty("user_id")]
	public long? UserId { get; set; }

	/// <summary>
	/// Самостоятельный ли был выход
	/// </summary>
	[JsonProperty("self")]
	public bool? IsSelf { get; set; }
}