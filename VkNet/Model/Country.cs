using System;
using Newtonsoft.Json;
using VkNet.Utils;

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

	#region public Methods

	/// <summary>
	/// Разобрать из json.
	/// </summary>
	/// <param name="response"> Ответ сервера. </param>
	/// <returns> </returns>
	public static Country FromJson(VkResponse response)
	{
		var country = new Country
		{
			Id = response[key: "comment_id"] ?? response[key: "cid"] ?? response[key: "id"],
			Title = response[key: "title"] ?? response[key: "name"]
		};

		return country;
	}

	#endregion
}