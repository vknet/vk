using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model;

/// <summary>
/// Регион
/// </summary>
[Serializable]
public class Region
{
	/// <summary>
	/// Идентификатор региона
	/// </summary>
	[JsonProperty("id")]
	public int Id { get; set; }

	/// <summary>
	/// Идентификатор региона
	/// </summary>
	[JsonProperty("region_id")]
	public int RegionId
	{
		get => Id;
		set => Id = value;
	}


	/// <summary>
	/// Название региона
	/// </summary>
	[JsonProperty("title")]
	public string Title { get; set; }

	/// <summary>
	/// Разобрать из json.
	/// </summary>
	/// <param name="response"> Ответ сервера. </param>
	/// <returns> </returns>
	public static Region FromJson(VkResponse response)
	{
		var region = new Region
		{
			Id = response[key: "region_id"] ?? response[key: "id"],
			Title = response[key: "title"]
		};

		return region;
	}
}