using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model;

/// <summary>
/// Объект для перечисления пользователей, которые выбрали определенные варианты ответа в опросе.
/// </summary>
[Serializable]
public class PollAnswerVoters
{
	/// <summary>
	/// Идентификатор варианта ответа
	/// </summary>
	[JsonProperty("answer_id")]
	public long? AnswerId { get; set; }

	/// <summary>
	/// Коллекция пользователей, только если Fields != null
	/// </summary>
	[JsonProperty("users")]
	public VkCollection<User> Users { get; set; }

	/// <summary>
	/// Коллекция идентификаторов пользователей, только если Fields = null
	/// </summary>
	[JsonProperty("items")]
	public VkCollection<long> UsersIds { get; set; }
}