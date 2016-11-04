using VkNet.Utils;

namespace VkNet.Model
{
    /// <summary>
    /// Информация об аудиоальбоме.
    /// </summary>
    /// <remarks>
    /// Страница документации ВКонтакте <see href="http://vk.com/dev/audio.getAlbums"/>.
    /// </remarks>
    public class AudioAlbum
    {
        /// <summary>
        /// Идентификатор владельца альбома.
        /// </summary>
        public long? OwnerId { get; set; }

        /// <summary>
        /// Идентификатор альбома.
        /// </summary>
        public long? AlbumId { get; set; }

        /// <summary>
        /// Название альбома.
        /// </summary>
        public string Title { get; set; }

		#region Методы
		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		internal static AudioAlbum FromJson(VkResponse response)
		{
			var album = new AudioAlbum
			{
				OwnerId = response["owner_id"],
				AlbumId = response["album_id"] ?? response["id"],
				Title = response["title"]
			};

			return album;
		}

		#endregion
	}
}