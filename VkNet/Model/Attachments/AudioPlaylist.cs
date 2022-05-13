using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model.Attachments
{
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
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
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

	#region Методы

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static AudioPlaylist FromJson(VkResponse response)
		{
			var playlist = new AudioPlaylist
			{
				Id = response["id"],
				OwnerId = response["owner_id"],
				Type = response["type"],
				Title = response["title"],
				Description = response["description"],
				Genres = response["genres"].ToReadOnlyCollectionOf<AudioPlaylistGenre>(x => x),
				Count = response["count"],
				IsFollowing = response["is_following"],
				Followers = response["followers"],
				Plays = response["plays"],
				CreateTime = response["create_time"],
				UpdateTime = response["update_time"],
				Year = response["year"],
				Original = response["original"],
				Follower = response["followed"],
				Photo = response["photo"],
				Thumbs = response["thumbs"].ToReadOnlyCollectionOf<AudioCover>(x => x),
				OwnerIds = response["display_owner_ids"].ToReadOnlyCollectionOf<long>(x => x),
				MainArtist = response["main_artist"],
				Artists = response["artists"].ToReadOnlyCollectionOf<AudioArtist>(x => x),
				MainArtists = response["main_artists"].ToReadOnlyCollectionOf<AudioArtist>(x => x),
				FeaturedArtists = response["featured_artists"].ToReadOnlyCollectionOf<AudioArtist>(x => x),
				AccessKey = response["access_key"],
				IsExplicit = response["is_explicit"]
			};

			return playlist;
		}

		/// <summary>
		/// Преобразование класса <see cref="AudioPlaylist" /> в
		/// <see cref="VkParameters" />
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> Результат преобразования в <see cref="AudioPlaylist" /> </returns>
		public static implicit operator AudioPlaylist(VkResponse response)
		{
			if (response == null)
			{
				return null;
			}

			return response.HasToken()
				? FromJson(response)
				: null;
		}

	#endregion
	}
}