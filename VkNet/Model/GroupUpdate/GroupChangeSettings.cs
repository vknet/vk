using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VkNet.Model.GroupUpdate;

/// <summary>
/// Событие о изменении настроек сообщества
/// </summary>
[Serializable]
public class GroupChangeSettings : IGroupUpdate
{
	/// <summary>
	/// Идентификатор пользователя, который внёс изменения;
	/// </summary>
	[JsonProperty("user_id")]
	public long? UserId { get; set; }

	/// <summary>
	/// Описание внесённых изменений
	/// </summary>
	[JsonProperty("changes")]
	public Dictionary<string, Change> Changes { get; set; }
}