using System;
using Newtonsoft.Json;

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
}