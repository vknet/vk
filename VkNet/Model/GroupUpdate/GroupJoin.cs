using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Enums;

namespace VkNet.Model;

/// <summary>
/// Добавление участника или заявки на вступление в сообщество
/// </summary>
[Serializable]
public class GroupJoin : IGroupUpdate
{
	/// <summary>
	/// Идентификатор пользователя
	/// </summary>
	[JsonProperty("user_id")]
	public long? UserId { get; set; }

	/// <summary>
	/// Указывает, как именно был добавлен участник.
	/// </summary>
	[JsonProperty("join_type")]
	[JsonConverter(typeof(StringEnumConverter))]
	public GroupJoinType? JoinType { get; set; }
}