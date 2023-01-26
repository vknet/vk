using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Информация о стране.
/// </summary>
[Serializable]
public class Country
{
	/// <summary>
	/// Идентификатор страны.
	/// </summary>
	[JsonProperty("id")]
	public long? Id { get; set; }

	[JsonProperty("cid")]
	private long? Cid
	{
		get => Id;
		set => Id = value;
	}

	[JsonProperty("comment_id")]
	private long? CommentId
	{
		get => Id;
		set => Id = value;
	}

	/// <summary>
	/// Название страны.
	/// </summary>
	[JsonProperty("title")]
	public string Title { get; set; }

	[JsonProperty("name")]
	private string Name
	{
		get => Title;
		set => Title = value;
	}
}