using System;
using System.Runtime.Serialization;
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
		public string Artist
		{ get; set; }

		/// <summary>
		/// Название композиции.
		/// </summary>
		public string Title
		{ get; set; }

		/// <summary>
		/// Длительность аудиозаписи в секундах.
		/// </summary>
		public int Duration
		{ get; set; }

		/// <summary>
		/// Ссылка на аудиозапись (привязана к ip-адресу клиентского приложения).
		/// </summary>
		public Uri Uri
		{ get; set; }

		/// <summary>
		/// Идентификатор текста аудиозаписи (если доступно).
		/// </summary>
		public long? LyricsId
		{ get; set; }

		/// <summary>
		/// Идентификатор альбома аудиозаписи (если присвоен).
		/// </summary>
		public long? AlbumId
		{ get; set; }

		/// <summary>
		/// Жанр аудиозаписи.
		/// </summary>
		public AudioGenre? Genre
		{ get; set; }

		/// <summary>
		/// Дата добавления.
		/// </summary>
		public DateTime? Date
		{ get; set; }

		#region Методы
		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		public static Audio FromJson(VkResponse response)
		{
			var audio = new Audio
			{
				Id = response["audio_id"] ?? response["aid"] ?? response["id"],
				OwnerId = response["owner_id"],
				Artist = response["artist"],
				Title = response["title"],
				Duration = response["duration"],
				Uri = response["url"],
				LyricsId = response["lyrics_id"],
				AlbumId = response["album_id"],
				Genre = response["genre_id"] ?? response["genre"],
				Date = response["date"]
			};
			return audio;
		}

		#endregion
	}
}