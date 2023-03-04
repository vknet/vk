using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Улица
/// </summary>
[Serializable]
public class Street
{
	/// <summary>
	/// Идентификатор улицы
	/// </summary>
	[JsonProperty("id")]
	public long Id { get; set; }

	/// <summary>
	/// Название улицы
	/// </summary>
	[JsonProperty("title")]
	public string Title { get; set; }
  
	[JsonProperty("name")]
	private string Name
	{
		get => Title;
		set => Title = value;
	}

	[JsonProperty("sid")]
	private long Sid
	{
		get => Id;
		set => Id = value;
	}
}