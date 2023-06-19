using System;
using Newtonsoft.Json;
using VkNet.Enums;

namespace VkNet.Model;

/// <summary>
/// Редактирование списка руководителей
/// </summary>
[Serializable]
public class GroupOfficersEdit : IGroupUpdate
{
	/// <summary>
	/// Идентификатор пользователя, чьи полномочия были изменены
	/// </summary>
	[JsonProperty("user_id")]
	public long? UserId { get; set; }

	/// <summary>
	/// Идентификатор руководителя, который внёс изменения
	/// </summary>
	[JsonProperty("admin_id")]
	public long? AdminId { get; set; }

	/// <summary>
	/// Новый уровень полномочий
	/// </summary>
	[JsonProperty("level_new")]
	public GroupOfficerLevel? LevelNew { get; set; }

	/// <summary>
	/// Старый уровень полномочий
	/// </summary>
	[JsonProperty("level_old")]
	public GroupOfficerLevel? LevelOld { get; set; }
}
