using System;
using Newtonsoft.Json;

namespace VkNet.Model.RequestParams;

/// <summary>
/// Параметры метода wall.addComment
/// </summary>
[Serializable]
public class BoardTopicParams
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
}