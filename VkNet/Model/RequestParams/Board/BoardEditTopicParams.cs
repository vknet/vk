using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Параметры метода wall.addComment
/// </summary>
[Serializable]
public class BoardEditTopicParams
{
	/// <summary>
	/// Идентификатор сообщества, в котором находится обсуждение.положительное число,
	/// обязательный параметр
	/// </summary>
	[JsonProperty(propertyName: "group_id")]
	public long GroupId { get; set; }

	/// <summary>
	/// Идентификатор сообщества, в котором находится обсуждение.положительное число,
	/// обязательный параметр
	/// </summary>
	[JsonProperty(propertyName: "topic_id")]
	public long TopicId { get; set; }

	/// <summary>
	/// Новое название обсуждения. Обязательный параметр.
	/// </summary>
	[JsonProperty(propertyName: "title")]
	public string Title { get; set; }

}