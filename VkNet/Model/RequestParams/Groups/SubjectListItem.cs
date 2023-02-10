using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model.RequestParams;

/// <summary>
/// Элемент списка возможных тематик
/// </summary>
[Serializable]
public class SubjectListItem
{
	/// <summary>
	/// идентификатор тематики;
	/// </summary>
	[JsonProperty("id")]
	public int Id { get; set; }

	/// <summary>
	/// название тематики.
	/// </summary>
	[JsonProperty("name")]
	public string Name { get; set; }

	/// <summary>
	/// Разобрать из json.
	/// </summary>
	/// <param name="response"> Ответ сервера. </param>
	/// <returns> </returns>
	public static SubjectListItem FromJson(VkResponse response) => new()
	{
		Id = response["id"],
		Name = response["name"]
	};
}