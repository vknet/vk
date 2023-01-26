using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Рейтинг.
/// </summary>
[Serializable]
public class Rating
{
	/// <summary>
	/// Количество звезд у продукта;.
	/// </summary>
	[JsonProperty("stars")]
	public long? Stars { get; set; }

	/// <summary>
	/// Количество отзывов о продукте;.
	/// </summary>
	[JsonProperty("reviews_count")]
	public long? ReviewsCount { get; set; }
}