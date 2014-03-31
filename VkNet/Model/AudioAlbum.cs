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

        internal static AudioAlbum FromJson(VkResponse response)
        {
            var album = new AudioAlbum();

            album.OwnerId = response["owner_id"];
            album.AlbumId = response["album_id"];
            album.Title = response["title"];

            return album;
        }

        #endregion
    }
}