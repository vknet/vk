using System;
using Newtonsoft.Json;

namespace VkNet.Model;

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
}