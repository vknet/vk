using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace VkNet.Model
{
	/// <summary>
	/// Плейлист.
	/// </summary>
	[Serializable]
	public class AudioPlaylist
	{
		/// <summary>
		/// Идентификатор плейлиста.
		/// </summary>
		[JsonProperty("id")]
		public long Id { get; set; }

		/// <summary>
		/// Идентификатор владельца плейлиста (пользователь или сообщество).
		/// </summary>
		[JsonProperty("owner_id")]
		public long OwnerId { get; set; }

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
		public IEnumerable<AudioPlaylistGenre> Genres { get; set; }

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
		public long Year { get; set; }

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
		public AudioCover Cover { get; set; }

		/// <summary>
		/// Ключ доступа.
		/// </summary>
		[JsonProperty("access_key")]
		public string AccessKey { get; set; }

		/// <summary>
		/// Главный исполнитель.
		/// </summary>
		[JsonProperty("main_artist")]
		public string MainArtist { get; set; }

		/// <summary>
		/// Список исполнителей.
		/// </summary>
		[JsonProperty("artists")]
		public IEnumerable<AudioPlaylistArtist> Artists { get; set; }
	}
}