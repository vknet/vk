﻿using System;
using Newtonsoft.Json;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model;

/// <summary>
/// Объект для перечисления пользователей, которые выбрали определенные варианты
/// ответа в опросе.
/// </summary>
[Serializable]
[JsonConverter(typeof(PollAnswerVotersJsonConverter))]
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
	public VkCollection<long> UsersIds { get; set; }
}