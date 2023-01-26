using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Метка в списке друзей
/// </summary>
[Serializable]
public class FriendList
{
	/// <summary>
	/// Идентификатор метки
	/// </summary>
	[JsonProperty("id")]
	public long Id { get; set; }

	/// <summary>
	/// Название метки
	/// </summary>
	[JsonProperty("name")]
	public string Name { get; set; }

	[JsonProperty("list_id")]
	private long ListId
	{
		get => Id;
		set => Id = value;
	}

	[JsonProperty("lid")]
	private long Lid
	{
		get => Id;
		set => Id = value;
	}
}