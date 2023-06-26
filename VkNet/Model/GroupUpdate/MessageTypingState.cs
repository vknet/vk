using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Объект, который содержит информацию о статусе печатании
/// </summary>
[Serializable]
public class MessageTypingState : IGroupUpdate
{
	/// <summary>
	/// Идентификатор пользователя, который набирает текст.
	/// </summary>
	[JsonProperty("from_id")]
	public long? FromId { get; set; }

	/// <summary>
	/// Идентификатор сообщества, которому пользователь пишет сообщение.
	/// </summary>
	[JsonProperty("to_id")]
	public long? ToId { get; set; }

	/// <summary>
	/// Состояние статуса набора текста.
	/// </summary>
	[JsonProperty("state")]
	public string State { get; set; }
}