using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Результат получения информации о музыкантах
/// </summary>
[Serializable]
public class GetMusiciansResult
{
	/// <summary>
	/// Идентификатор музыканта.
	/// </summary>
	[JsonProperty("id")]
	public long Id { get; set; }

	/// <summary>
	/// Полный псевдоним музыканта.
	/// </summary>
	[JsonProperty("name")]
	public string Name { get; set; }

	/// <summary>
	/// Аватарка музыканта.
	/// </summary>
	[JsonProperty("avatar")]
	public string Avatar { get; set; }
}