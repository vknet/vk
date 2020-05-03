using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model
{
	/// <summary>
	/// Информация о метаданных плейлисте каталога.
	/// </summary>
	[Serializable]
	public class AudioCatalogPlaylist
	{
		/// <summary>
		/// Идентификатор.
		/// </summary>
		[JsonProperty("id")]
		public long Id { get; set; }

		/// <summary>
		/// Идентификатор владельца.
		/// </summary>
		[JsonProperty("owner_id")]
		public long OwnerId { get; set; }

		/// <summary>
		/// Тип.
		/// </summary>
		[JsonProperty("type")]
		public int Type { get; set; }

		/// <summary>
		/// Название.
		/// </summary>
		[JsonProperty("title")]
		public string Title { get; set; }

		/// <summary>
		/// Описание.
		/// </summary>
		[JsonProperty("description")]
		public string Description { get; set; }

		/// <summary>
		/// Количество.
		/// </summary>
		[JsonProperty("count")]
		public long Count { get; set; }

		/// <summary>
		/// Количество слушателей(подписчиков).
		/// </summary>
		[JsonProperty("followers")]
		public long Followers { get; set; }

		/// <summary>
		/// Количество прослушиваний.
		/// </summary>
		[JsonProperty("plays")]
		public long Plays { get; set; }

		/// <summary>
		/// Дата создания.
		/// </summary>
		[JsonProperty("create_time")]
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime CreateTime { get; set; }

		/// <summary>
		/// Дата обновления.
		/// </summary>
		[JsonProperty("update_time")]
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime UpdateTime { get; set; }

		/// <summary>
		/// Жанры.
		/// </summary>
		[JsonProperty("genres")]
		public ReadOnlyCollection<AudioPlaylistGenre> Genres { get; set; }

		/// <summary>
		/// Год.
		/// </summary>
		[JsonProperty("year")]
		public int Year { get; set; }

		/// <summary>
		/// Оригинал.
		/// </summary>
		[JsonProperty("original")]
		public AudioPlaylistOriginal Original { get; set; }

		/// <summary>
		/// Фото.
		/// </summary>
		[JsonProperty("photo")]
		public AudioCatalogAudioAlbumThumb Photo { get; set; }

		/// <summary>
		/// Ключ доступа.
		/// </summary>
		[JsonProperty("access_key")]
		public string AccessKey { get; set; }

		/// <summary>
		/// Являетя ли откровенным контентом.
		/// </summary>
		[JsonProperty("is_explicit")]
		public bool IsExplicit { get; set; }

		/// <summary>
		/// Главные исполнители
		/// </summary>
		[JsonProperty("main_artists")]
		public ReadOnlyCollection<AudioArtist> MainArtists { get; set; }

		/// <summary>
		/// Тип альбома.
		/// </summary>
		[JsonProperty("album_type")]
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public AudioAlbumType AlbumType { get; set; }
	}
}