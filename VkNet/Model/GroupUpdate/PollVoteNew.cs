using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Добавление голоса в публичном опросе
/// </summary>
[Serializable]
public class PollVoteNew : IGroupUpdate
{
	/// <summary>
	/// Идентификатор пользователя
	/// </summary>
	[JsonProperty("user_id")]
	public long? UserId { get; set; }

	/// <summary>
	/// Идентификатор опроса
	/// </summary>
	[JsonProperty("poll_id")]
	public long? PollId { get; set; }

	/// <summary>
	/// Идентификатор варианта ответа
	/// </summary>
	[JsonProperty("option_id")]
	public long? OptionId { get; set; }

	/// <summary>
	/// Идентификатор владельца опроса
	/// </summary>
	[JsonProperty("owner_id")]
	public long? OwnerId { get; set; }
}