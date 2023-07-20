using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Добавление участника или заявки на вступление в сообщество
/// </summary>
[Serializable]
public class DonutEnd : IGroupUpdate
{
	/// <summary>
	/// Идентификатор пользователя
	/// </summary>
	[JsonProperty("user_id")]
	public long? UserId { get; set; }
}