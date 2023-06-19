using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Enums;

namespace VkNet.Model;

/// <summary>
/// Аудиозапись пользователя или группы.
/// См. описание http://vk.com/dev/audio_object
/// </summary>
[Serializable]
public class Audio : MediaAttachment, IGroupUpdate
{
	/// <inheritdoc />
	protected override string Alias => "audio";

	/// <summary>
	/// Исполнитель аудиозаписи.
	/// </summary>
	[JsonProperty("artist")]
	public string Artist { get; set; }

	/// <summary>
	/// Название композиции.
	/// </summary>
	[JsonProperty("title")]
	public string Title { get; set; }

	/// <summary>
	/// Длительность аудиозаписи в секундах.
	/// </summary>
	[JsonProperty("duration")]
	public int Duration { get; set; }

	/// <summary>
	/// Дата добавления.
	/// </summary>
	[JsonConverter(typeof(UnixDateTimeConverter))]
	[JsonProperty("date")]
	public DateTime Date { get; set; }

	/// <summary>
	/// Ссылка на аудиозапись (привязана к ip-адресу клиентского приложения).
	/// </summary>
	[JsonProperty("url")]
	public Uri Url { get; set; }

	/// <summary>
	/// Альбом аудиозаписи.
	/// </summary>
	[JsonProperty("album")]
	public AudioAlbum Album { get; set; }

	/// <summary>
	/// <c>true</c>, если аудиозапись лицензируется.
	/// </summary>
	[JsonProperty("is_licensed")]
	public bool? IsLicensed { get; set; }

	/// <summary>
	/// <c>true</c>, если аудиозапись в высоком качестве.
	/// </summary>
	[JsonProperty("is_hq")]
	public bool? IsHq { get; set; }

	/// <summary>
	/// Жанр аудиозаписи.
	/// </summary>
	[JsonProperty("track_genre_id")]
	public AudioGenre? TrackGenre { get; set; }

	/// <summary>
	/// Жанр аудиозаписи.
	/// </summary>
	[JsonProperty("genre")]
	public AudioGenre? Genre { get; set; }

	/// <summary>
	/// Идентификатор текста аудиозаписи (если доступно).
	/// </summary>
	[JsonProperty("lyrics_id")]
	public long? LyricsId { get; set; }

	/// <summary>
	/// Содержит ли трек ненормативную лексику.
	/// </summary>
	[JsonProperty("is_explicit")]
	public bool IsExplicit { get; set; }

	/// <summary>
	/// Получено экспериментально
	/// </summary>
	[JsonProperty("is_focus_track")]
	public bool IsFocusTrack { get; set; }

	/// <summary>
	/// Возможно ли использование обложки этого трека в "Историях" (получено экспериментально)
	/// </summary>
	[JsonProperty("stories_cover_allowed")]
	public bool? StoriesCoverAllowed { get; set; }

	/// <summary>
	/// Возможно ли использование этого трека в "Историях" (получено экспериментально)
	/// </summary>
	[JsonProperty("stories_allowed")]
	public bool? StoriesAllowed { get; set; }

	/// <summary>
	/// Возможно ли использование этого трека в "Клипах" (получено экспериментально)
	/// </summary>
	[JsonProperty("short_videos_allowed")]
	public bool? ShortVideosAllowed { get; set; }

	/// <summary>
	/// Список главных исполнителей.
	/// </summary>
	[JsonProperty("main_artists")]
	public IEnumerable<AudioArtist> MainArtists { get; set; }

	/// <summary>
	/// Список второстепенных исполнителей.
	/// </summary>
	[JsonProperty("featured_artists")]
	public IEnumerable<AudioArtist> FeaturedArtists { get; set; }

	/// <summary>
	/// Подзаголовок(?)  композиции.
	/// </summary>
	[JsonProperty("subtitle")]
	public string Subtitle { get; set; }

	/// <summary>
	/// Неизвестно (получено экспериментально).
	/// </summary>
	[JsonProperty("track_code")]
	public string TrackCode { get; set; }

	/// <summary>
	/// Неизвестно (получено экспериментально).
	/// </summary>
	[JsonProperty("content_restricted")]
	public long ContentRestricted { get; set; }

	[JsonProperty("genre_id")]
	private AudioGenre? GenreId
	{
		get => Genre;
		set => Genre = value;
	}
}