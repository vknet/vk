using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace VkNet.Model;

/// <summary>
/// Подборка товаров
/// </summary>
[Serializable]
public class MarketAlbum : MediaAttachment
{
	/// <inheritdoc />
	protected override string Alias => "market_album";

	/// <summary>
	/// Название подборки
	/// </summary>
	[JsonProperty("title")]
	public string Title { get; set; }

	/// <summary>
	/// Обложка подборки, объект, описывающий фотографию.
	/// </summary>
	[JsonProperty("photo")]
	public Photo Photo { get; set; }

	/// <summary>
	/// Число товаров в подборке.
	/// </summary>
	[JsonProperty("count")]
	public int Count { get; set; }

	/// <summary>
	/// Дата обновления подборки в формате Unixtime.
	/// </summary>
	[JsonProperty("updated_time")]
	[JsonConverter(typeof(UnixDateTimeConverter))]
	public DateTime? UpdatedTime { get; set; }
}