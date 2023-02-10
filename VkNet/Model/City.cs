using System;
using Newtonsoft.Json;
using VkNet.Utils;

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
	/// Идентификатор города.
	/// </summary>
	[JsonProperty("id")]
	public long? Id { get; set; }

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

	#region Inernal Methods

	/// <summary>
	/// Разобрать из json.
	/// </summary>
	/// <param name="response"> Ответ сервера. </param>
	/// <returns> </returns>
	public static City FromJson(VkResponse response)
	{
		string id = response[key: "comment_id"] ?? response[key: "cid"] ?? response[key: "id"];

		return new()
		{
			Id = Convert.ToInt64(value: id),
			Title = response[key: "title"] ?? response[key: "name"],
			Area = response[key: "area"],
			Region = response[key: "region"],
			Important = response[key: "important"] ?? false
		};
	}

	#endregion
}