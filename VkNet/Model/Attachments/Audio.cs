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
			RegisterType(type: typeof(Audio), match: "audio");
		}

		/// <summary>
		/// Исполнитель аудиозаписи.
		/// </summary>
		public string Artist { get; set; }

		/// <summary>
		/// Название композиции.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Длительность аудиозаписи в секундах.
		/// </summary>
		public int Duration { get; set; }

		/// <summary>
		/// Ссылка на аудиозапись (привязана к ip-адресу клиентского приложения).
		/// </summary>
		public Uri Uri { get; set; }

		/// <summary>
		/// Идентификатор текста аудиозаписи (если доступно).
		/// </summary>
		public long? LyricsId { get; set; }

		/// <summary>
		/// Идентификатор альбома аудиозаписи (если присвоен).
		/// </summary>
		public long? AlbumId { get; set; }

		/// <summary>
		/// Жанр аудиозаписи.
		/// </summary>
		public AudioGenre? Genre { get; set; }

		/// <summary>
		/// Дата добавления.
		/// </summary>
		[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
		public DateTime? Date { get; set; }

	#region Методы

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static Audio FromJson(VkResponse response)
		{
			var audio = new Audio
			{
					Id = response[key: "audio_id"] ?? response[key: "aid"] ?? response[key: "id"]
					, OwnerId = response[key: "owner_id"]
					, Artist = response[key: "artist"]
					, Title = response[key: "title"]
					, Duration = response[key: "duration"]
					, Uri = response[key: "url"]
					, LyricsId = response[key: "lyrics_id"]
					, AlbumId = response[key: "album_id"]
					, Genre = response[key: "genre_id"] ?? response[key: "genre"]
					, Date = response[key: "date"]
			};

			return audio;
		}

	#endregion
	}
}