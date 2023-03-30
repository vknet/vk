using System;
using Newtonsoft.Json;
using VkNet.Enums.SafetyEnums;

namespace VkNet.Model;

/// <summary>
/// Информация о собеседнике.
/// </summary>
[Serializable]
public class Peer
{
	/// <summary>
	/// Идентификатор назначения.
	/// </summary>
	[JsonProperty("id")]
	public long Id { get; set; }

	/// <summary>
	/// Тип.
	/// </summary>
	[JsonProperty("type")]
	public ConversationPeerType Type { get; set; }

	/// <summary>
	/// Локальный идентификатор назначения.
	/// </summary>
	[JsonProperty("local_id")]
	public long LocalId { get; set; }
}