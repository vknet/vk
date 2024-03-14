using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Результат выполнения запроса установки ограничений участнику чата
/// </summary>
[Serializable]
public class MessagesChangeConversationMemberRestrictionsObject
{
	/// <summary>
	/// Список идентификаторов, к которым не удалось применить ограничения
	/// </summary>
	[JsonProperty("failed_member_ids")]
	public ReadOnlyCollection<long> FailedMemberIds { get; set; }
}