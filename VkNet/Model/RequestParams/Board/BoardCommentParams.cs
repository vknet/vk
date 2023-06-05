using System;
using Newtonsoft.Json;

namespace VkNet.Model.RequestParams;

/// <summary>
/// Параметры метода wall.addComment
/// </summary>
[Serializable]
public class BoardCommentParams
{
	/// <summary>
	/// Идентификатор сообщества, в котором находится обсуждение. положительное число,
	/// обязательный параметр
	/// </summary>
	[JsonProperty(propertyName: "group_id")]
	public long GroupId { get; set; }

	/// <summary>
	/// Идентификатор обсуждения. положительное число,
	/// обязательный параметр
	/// </summary>
	[JsonProperty(propertyName: "topic_id")]
	public long TopicId { get; set; }

	/// <summary>
	/// Идентификатор комментария в обсуждении, обязательный параметр.
	/// </summary>
	[JsonProperty(propertyName: "comment_id")]
	public long CommentId { get; set; }
}