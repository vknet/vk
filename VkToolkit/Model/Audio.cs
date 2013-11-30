using System;

using VkToolkit.Utils;

namespace VkToolkit.Model
{
    /// <summary>
    /// Аудиозапись пользователя или группы.
    /// </summary>
    /// <remarks>
    /// Страница документации ВКонтакте http://vk.com/pages.php?o=-1&p=audio.get
    /// </remarks>
    public class Audio
    {
        /// <summary>
        /// Идентификатор аудиозаписи.
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Идентификатор владельца аудиозаписи (пользователя или группы).
        /// Для группы идентификатор отрицательный и равен -gid.
        /// </summary>
        public long OwnerId { get; set; }
        /// <summary>
        /// Исполнитель аудиозаписи.
        /// </summary>
        public string Artist { get; set; }
        /// <summary>
        /// Название аудиозаписи.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Длительность аудиозаписи в секундах.
        /// </summary>
        public int Duration { get; set; }
        /// <summary>
        /// Ссылка на аудиозапись (привязана к ip-адресу клиентского приложения).
        /// </summary>
        public Uri Url { get; set; }
        /// <summary>
        /// Идентификатор слов аудиозаписи.
        /// </summary>
        public long? LyricsId { get; set; }
        /// <summary>
        /// Идентификатор альбома аудиозаписи (если он есть).
        /// </summary>
        public long? AlbumId { get; set; }

        internal static Audio FromJson(VkResponse audio)
        {
            // TODO: case when album id is not null
            var result = new Audio();

            result.Id = audio["aid"];
            result.OwnerId = audio["owner_id"];
            result.Artist = audio["artist"];
            result.Title = audio["title"];
            result.Duration = audio["duration"];
            result.Url = audio["url"];
            result.LyricsId = audio["lyrics_id"];
            result.AlbumId = audio["album"];

            return result;
        }
    }
}
