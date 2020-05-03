using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace VkNet.Model
{
	/// <summary>
	/// Информация об аудиозаписи каталога.
	/// </summary>
	[Serializable]
	public class AudioCatalogAudio
	{
		/// <summary>
		/// Имя исполнителя.
		/// </summary>
		[JsonProperty("artist")]
		public string Artist { get; set; }

		/// <summary>
		/// Идентификатор владельца аудиозаписи.
		/// </summary>
		[JsonProperty("owner_id")]
		public long OwnerId { get; set; }

		/// <summary>
		/// Название альбома.
		/// </summary>
		[JsonProperty("title")]
		public string Title { get; set; }

		/// <summary>
		/// Длительность.
		/// </summary>
		[JsonProperty("duration")]
		public int Duration { get; set; }

		/// <summary>
		/// Идентификатор.
		/// </summary>
		[JsonProperty("id")]
		public long Id { get; set; }

		/// <summary>
		/// Ключ доступа.
		/// </summary>
		[JsonProperty("access_key")]
		public string AccessKey { get; set; }

		/// <summary>
		/// Реклама.
		/// </summary>
		[JsonProperty("ads")]
		public AudioCatalogAudioAds Ads { get; set; }

		/// <summary>
		/// Ключ доступа.
		/// </summary>
		[JsonProperty("is_explicit")]
		public bool IsExplicit { get; set; }

		/// <summary>
		/// Реклама.
		/// </summary>
		[JsonProperty("is_focus_track")]
		public bool IsFocusTrack { get; set; }

		/// <summary>
		/// Ключ доступа.
		/// </summary>
		[JsonProperty("track_code")]
		public string TrackCode { get; set; }

		/// <summary>
		/// Реклама.
		/// </summary>
		[JsonProperty("url")]
		public string Url { get; set; }

		/// <summary>
		/// Ключ доступа.
		/// </summary>
		[JsonProperty("date")]
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime Date { get; set; }

		/// <summary>
		/// Альбом.
		/// </summary>
		[JsonProperty("album")]
		public AudioAlbum Album { get; set; }

		/// <summary>
		/// Главные исполнители.
		/// </summary>
		[JsonProperty("main_artists")]
		public ReadOnlyCollection<AudioArtist> MainArtists { get; set; }

		/// <summary>
		/// Вторичные исполнители.
		/// </summary>
		[JsonProperty("featured_artists")]
		public ReadOnlyCollection<AudioArtist> FeaturedArtists { get; set; }

		/// <summary>
		/// Разрешены ли истории.
		/// </summary>
		[JsonProperty("stories_allowed")]
		public bool StoriesAllowed { get; set; }
	}
}