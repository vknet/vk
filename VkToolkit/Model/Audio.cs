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

        internal static Audio FromJson(VkResponse response)
        {
            var audio = new Audio();

            audio.Id = response["aid"];
            audio.OwnerId = response["owner_id"];
            audio.Artist = response["artist"];
            audio.Title = response["title"];
            audio.Duration = response["duration"];
            audio.Url = response["url"];
            audio.LyricsId = response["lyrics_id"];
            audio.AlbumId = response["album"];

            return audio;
        }
    }
}
