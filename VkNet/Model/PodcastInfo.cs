using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Информация о подкасте
/// </summary>
[Serializable]
public class PodcastInfo
{
	/// <summary>
	/// Обложка.
	/// </summary>
	[JsonProperty("cover")]
	public Cover Cover { get; set; }

	/// <summary>
	/// Количество прослушиваний.
	/// </summary>
	[JsonProperty("plays")]
	public long Plays { get; set; }

	/// <summary>
	/// Важный.
	/// </summary>
	[JsonProperty("is_favorite")]
	public bool IsFavorite { get; set; }

	/// <summary>
	/// Позиция.
	/// </summary>
	[JsonProperty("position")]
	public long? Position { get; set; }

	/// <summary>
	/// Описание.
	/// </summary>
	[JsonProperty("description")]
	public string Description { get; set; }
}