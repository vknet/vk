using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Город.
/// </summary>
/// <remarks>
/// Страница документации ВКонтакте http://vk.com/dev/database.getCities
/// </remarks>
[Serializable]
public class City
{
	/// <summary>
	/// Название города.
	/// </summary>
	[JsonProperty("title")]
	public string Title { get; set; }

	/// <summary>
	/// Район.
	/// </summary>
	[JsonProperty("area")]
	public string Area { get; set; }

	/// <summary>
	/// Область.
	/// </summary>
	[JsonProperty("region")]
	public string Region { get; set; }

	/// <summary>
	/// Является ли город основным.
	/// </summary>
	[JsonProperty("important")]
	public bool Important { get; set; }

	[JsonProperty("comment_id")]
	private long? CommentId
	{
		get => Id;
		set => Id = value;
	}

	[JsonProperty("cid")]
	private long? Cid
	{
		get => Id;
		set => Id = value;
	}

	[JsonProperty("name")]
	private string Name
	{
		get => Title;
		set => Title = value;
	}
}
