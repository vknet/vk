using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace VkNet.Model;

/// <summary>
/// Подкаст
/// </summary>
[Serializable]
public class Podcast : MediaAttachment
{
	/// <inheritdoc />
	protected override string Alias => "podcast";

	/// <summary>
	/// Заголовок подкаста
	/// </summary>
	[JsonProperty("podcast_title")]
	public string PodcastTitle { get; set; }

	/// <summary>
	/// Исполнитель
	/// </summary>
	[JsonProperty("artist")]
	public string Artist { get; set; }

	/// <summary>
	/// Заголовок
	/// </summary>
	[JsonProperty("title")]
	public string Title { get; set; }

	/// <summary>
	/// Длительность
	/// </summary>
	[JsonProperty("duration")]
	public long? Duration { get; set; }

	/// <summary>
	/// Дата
	/// </summary>
	[JsonProperty("date")]
	[JsonConverter(typeof(UnixDateTimeConverter))]
	public DateTime? Date { get; set; }

	/// <summary>
	/// <c>Uri</c> на подкаст
	/// </summary>
	[JsonProperty("url")]
	public Uri Url { get; set; }

	/// <summary>
	/// Идентификатор текста песни
	/// </summary>
	[JsonProperty("lyrics_id")]
	public long? LyricsId { get; set; }

	/// <summary>
	/// Не искать
	/// </summary>
	[JsonProperty("no_search")]
	public bool? NoSearch { get; set; }

	/// <summary>
	/// Высокое качество
	/// </summary>
	[JsonProperty("is_hq")]
	public bool? IsHq { get; set; }

	/// <summary>
	/// Явный
	/// </summary>
	[JsonProperty("is_explicit")]
	public bool? IsExplicit { get; set; }

	/// <summary>
	/// Информация о подкасте
	/// </summary>
	[JsonProperty("podcast_info")]
	public PodcastInfo PodcastInfo { get; set; }

	/// <summary>
	/// Код трека.
	/// </summary>
	[JsonProperty("track_code")]
	public string TrackCode { get; set; }
}