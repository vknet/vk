using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Ответ метода Stories.GetViewers
/// </summary>
[Serializable]
public class StoryViewers
{
	/// <summary>
	/// Поставил ли пользователь лайк
	/// </summary>
	[JsonProperty(propertyName: "is_liked")]
	public bool IsLiked { get; set; }

	/// <summary>
	/// Идентификатор пользователя
	/// </summary>
	[JsonProperty(propertyName: "user_id")]
	public ulong UserId { get; set; }
}