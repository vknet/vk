using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Enums;
using VkNet.Utils;

namespace VkNet.Model.Attachments
{
	/// <summary>
	/// Аудиозапись пользователя или группы.
	/// См. описание http://vk.com/dev/audio_object
	/// </summary>
	[Serializable]
	public class Audio : MediaAttachment
	{
		static Audio()
		{
			RegisterType(typeof(Audio), "audio");
		}

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
		/// true, если аудиозапись лицензируется.
		/// </summary>
		[JsonProperty("is_licensed")]
		public bool? IsLicensed { get; set; }

		/// <summary>
		/// true, если аудиозапись в высоком качестве.
		/// </summary>
		[JsonProperty("is_hq")]
		public bool? IsHq { get; set; }

		/// <summary>
		/// Жанр аудиозаписи.
		/// </summary>
		[JsonProperty("track_genre_id")]
		public AudioGenre? TrackGenre { get; set; }

		/// <summary>
		/// Ключ доступа.
		/// </summary>
		[JsonProperty("access_key")]
		public string AccessKey { get; set; }

		/// <summary>
		/// Жанр аудиозаписи.
		/// </summary>
		[JsonProperty("genre_id")]
		public AudioGenre? Genre { get; set; }

		/// <summary>
		/// Идентификатор текста аудиозаписи (если доступно).
		/// </summary>
		[JsonProperty("lyrics_id")]
		public long? LyricsId { get; set; }

		/// <summary>
		/// Неизвестно.
		/// </summary>
		[JsonProperty("content_restricted")]
		public int? ContentRestricted { get; set; }

	#region Методы

		/// <inheritdoc />
		public override string ToString()
		{
			return string.IsNullOrWhiteSpace(AccessKey)
				? base.ToString()
				: $"{base.ToString()}_{AccessKey}";
		}

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static Audio FromJson(VkResponse response)
		{
			return new Audio
			{
				Id = response["id"],
				OwnerId = response["owner_id"],
				Artist = response["artist"],
				Title = response["title"],
				Duration = response["duration"],
				Url = response["url"],
				LyricsId = response["lyrics_id"],
				Album = response["album"],
				AccessKey = response["access_key"],
				IsHq = response["is_hq"],
				IsLicensed = response["is_licensed"],
				TrackGenre = response["track_genre_id"],
				ContentRestricted = response["content_restricted"],
				Genre = response["genre_id"] ?? response["genre"],
				Date = response["date"]
			};
		}

	#endregion
	}
}