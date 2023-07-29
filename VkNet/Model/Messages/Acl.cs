using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Акк
/// </summary>
[Serializable]
public class Acl
{
	/// <summary>
	/// Признак возможности пригласить
	/// </summary>
	[JsonProperty("can_invite")]
	public bool CanInvite { get; set; }

	/// <summary>
	/// Признак возможности изменить информацию
	/// </summary>
	[JsonProperty("can_change_info")]
	public bool CanChangeInfo { get; set; }

	/// <summary>
	/// Признак возможности изменить закрепление
	/// </summary>
	[JsonProperty("can_change_pin")]
	public bool CanChangePin { get; set; }

	/// <summary>
	/// Признак возможности повысить пользователей
	/// </summary>
	[JsonProperty("can_promote_users")]
	public bool CanPromoteUsers { get; set; }

	/// <summary>
	/// Признак возможности видеть ссылки на приглашение
	/// </summary>
	[JsonProperty("can_see_invite_link")]
	public bool CanSeeInviteLink { get; set; }

	/// <summary>
	/// Признак возможности изменить ссылку на приглашение
	/// </summary>
	[JsonProperty("can_change_invite_link")]
	public bool CanChangeInviteLink { get; set; }

	/// <summary>
	/// Признак возможности модерировать
	/// </summary>
	[JsonProperty("can_moderate")]
	public bool CanModerate { get; set; }

	/// <summary>
	/// Признак возможности копировать чат
	/// </summary>
	[JsonProperty("can_copy_chat")]
	public bool CanCopyChat { get; set; }
}