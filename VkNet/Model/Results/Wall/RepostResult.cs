using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Результат запроса wall.Repost
/// </summary>
[Serializable]
public class RepostResult
{
	/// <summary>
	/// всегда содержит 1;
	/// </summary>
	[JsonProperty("success")]
	public bool Success { get; set; }

	/// <summary>
	/// идентификатор созданной записи;
	/// </summary>
	[JsonProperty("post_id")]
	public long? PostId { get; set; }

	/// <summary>
	/// количество репостов объекта с учетом осуществленного;
	/// </summary>
	[JsonProperty("reposts_count")]
	public int? RepostsCount { get; set; }

	/// <summary>
	/// число отметок «Мне нравится» у объекта.
	/// </summary>
	[JsonProperty("likes_count")]
	public int? LikesCount { get; set; }
}