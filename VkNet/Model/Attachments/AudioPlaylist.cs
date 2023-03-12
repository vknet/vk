using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model.Attachments;

/// <summary>
/// Плейлист.
/// </summary>
[Serializable]
public class AudioPlaylist : MediaAttachment
{
	/// <inheritdoc />
	protected override string Alias => "audio_playlist";

	/// <summary>
	/// Тип плейлиста.
	/// </summary>
	[JsonProperty("album_type")]
	public AudioAlbumType AlbumType { get; set; }

	/// <summary>
	/// Тип плейлиста.
	/// </summary>
	[JsonProperty("type")]
	public long Type { get; set; }

	/// <summary>
	/// Название плейлиста.
	/// </summary>
	[JsonProperty("title")]
	public string Title { get; set; }

	/// <summary>
	/// Описание плейлиста.
	/// </summary>
	[JsonProperty("description")]
	public string Description { get; set; }

	/// <summary>
	/// Список жанров плейлиста.
	/// </summary>
	[JsonProperty("genres")]
	public ReadOnlyCollection<AudioPlaylistGenre> Genres { get; set; }

	/// <summary>
	/// Количество аудиозаписей в плейлисте.
	/// </summary>
	[JsonProperty("count")]
	public long Count { get; set; }

	/// <summary>
	/// true, если плейлист добавлен в аудиозаписи.
	/// </summary>
	[JsonProperty("is_following")]
	public bool IsFollowing { get; set; }

	/// <summary>
	/// Количество добавлений плейлиста.
	/// </summary>
	[JsonProperty("followers")]
	public long Followers { get; set; }

	/// <summary>
	/// Общее количество проигрываний плейлиста.
	/// </summary>
	[JsonProperty("plays")]
	public long Plays { get; set; }

	/// <summary>
	/// Дата создания плейлиста.
	/// </summary>
	[JsonConverter(typeof(UnixDateTimeConverter))]
	[JsonProperty("create_time")]
	public DateTime CreateTime { get; set; }

	/// <summary>
	/// Дата обновления плейлиста.
	/// </summary>
	[JsonConverter(typeof(UnixDateTimeConverter))]
	[JsonProperty("update_time")]
	public DateTime UpdateTime { get; set; }

	/// <summary>
	/// Год выпуска альбома.
	/// </summary>
	[JsonProperty("year")]
	public long? Year { get; set; }

	/// <summary>
	/// Неизвестно.
	/// </summary>
	[JsonProperty("original")]
	public AudioPlaylistOriginal Original { get; set; }

	/// <summary>
	/// Информация о подписчике плейлиста.
	/// </summary>
	[JsonProperty("followed")]
	public AudioPlaylistFollower Follower { get; set; }

	/// <summary>
	/// Обложка плейлиста.
	/// </summary>
	[JsonProperty("photo")]
	public AudioCover Photo { get; set; }

	/// <summary>
	/// Миниатюры плейлиста.
	/// </summary>
	[JsonProperty("thumbs")]
	public ReadOnlyCollection<AudioCover> Thumbs { get; set; }

	/// <summary>
	/// Неизвестно.
	/// </summary>
	[JsonProperty("display_owner_ids")]
	public ReadOnlyCollection<long> OwnerIds { get; set; }

	/// <summary>
	/// Главный исполнитель.
	/// </summary>
	[Obsolete("Use MainArtists property instead.")]
	[JsonProperty("main_artist")]
	public string MainArtist { get; set; }

	/// <summary>
	/// Список исполнителей.
	/// </summary>
	[Obsolete("Use MainArtists property instead.")]
	[JsonProperty("artists")]
	public ReadOnlyCollection<AudioArtist> Artists { get; set; }

	/// <summary>
	/// Список исполнителей.
	/// </summary>
	[JsonProperty("main_artists")]
	public ReadOnlyCollection<AudioArtist> MainArtists { get; set; }

	/// <summary>
	/// Список исполнителей.
	/// </summary>
	[JsonProperty("featured_artists")]
	public ReadOnlyCollection<AudioArtist> FeaturedArtists { get; set; }

	/// <summary>
	/// Являетя ли откровенным контентом.
	/// </summary>
	[JsonProperty("is_explicit")]
	public bool IsExplicit { get; set; }
}