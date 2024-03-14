using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using VkNet.Enums.StringEnums;

namespace VkNet.Model;

/// <summary>
/// Список параметров для метода messages.changeConversationMemberRestrictions
/// </summary>
[Serializable]
public class MessagesChangeConversationMemberRestrictionsParams
{
	/// <summary>
	/// Идентификатор назначения.
	/// </summary>
	[JsonProperty("peer_id")]
	public long PeerId { get; set; }

	/// <summary>
	/// Идентификаторы пользователей.
	/// </summary>
	[JsonProperty("member_ids")]
	public IEnumerable<long> MemberIds { get; set; }

	/// <summary>
	/// Время в секундах. Если нужно замутить навсегда, то указывать не нужно.
	/// </summary>
	[JsonProperty("for", NullValueHandling = NullValueHandling.Ignore)]
	public long For { get; set; }

	/// <summary>
	/// Разрешенные действия.
	/// </summary>
	[JsonProperty("action")]
	public ConversationMemberRestrictionsActionType Action { get; set; }
}