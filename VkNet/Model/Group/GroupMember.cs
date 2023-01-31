using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Информация о участнике сообщества (группы).
/// См. описание http://vk.com/dev/fields_groups
/// </summary>
[Serializable]
public class GroupMember
{
	#region Стандартные поля

	/// <summary>
	/// Идентификатор пользователя ВК.
	/// </summary>
	[JsonProperty("user_id")]
	public ulong? UserId { get; set; }

	/// <summary>
	/// Является ли пользователь участником сообщества;
	/// </summary>
	[JsonProperty("member")]
	public bool Member { get; set; }

	/// <summary>
	/// Есть ли непринятая заявка от пользователя на вступление в группу (такую заявку
	/// можно отозвать методом
	/// groups.leave).
	/// </summary>
	[JsonProperty("request")]
	public bool? Request { get; set; }

	/// <summary>
	/// Приглашён ли пользователь в группу или встречу.
	/// </summary>
	[JsonProperty("invitation")]
	public bool? Invitation { get; set; }

	#endregion
}