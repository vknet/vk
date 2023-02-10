using System;
using Newtonsoft.Json;
using VkNet.Utils;

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

	#region public Methods

	/// <summary>
	/// Разобрать из json.
	/// </summary>
	/// <param name="response"> Ответ сервера. </param>
	/// <returns> </returns>
	public static FriendList FromJson(VkResponse response)
	{
		var list = new FriendList
		{
			Id = response[key: "list_id"] ?? response[key: "lid"] ?? response[key: "id"],
			Name = response[key: "name"]
		};

		return list;
	}

	#endregion
}