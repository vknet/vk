using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Изменение главного фото
/// </summary>
[Serializable]
public class GroupChangePhoto : IGroupUpdate
{
	/// <summary>
	/// Идентификатор пользователя, который внес изменения
	/// </summary>
	[JsonProperty("user_id")]
	public long? UserId { get; set; }

	/// <summary>
	/// Фотография
	/// </summary>
	[JsonProperty("photo")]
	public Photo Photo { get; set; }
}