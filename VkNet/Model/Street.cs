using System;
using Newtonsoft.Json;
using VkNet.Utils;

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

	#region public Methods

	/// <summary>
	/// Разобрать из json.
	/// </summary>
	/// <param name="response"> Ответ сервера. </param>
	/// <returns> </returns>
	public static Street FromJson(VkResponse response)
	{
		var street = new Street
		{
			Id = response[key: "sid"] ?? response[key: "id"],
			Title = response[key: "name"]
		};

		return street;
	}

	#endregion
}