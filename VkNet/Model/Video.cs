namespace VkNet.Model
{
    using System;

    using VkNet.Utils;

    /// <summary>
    /// Видеозапись пользователя или группы.
    /// См. описание <see cref="http://vk.com/dev/video_object"/>.
    /// </summary>
    public class Video
    {
        /// <summary>
        /// Идентификатор видеозаписи.
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Идентификатор владельца видеозаписи.
        /// </summary>
        public long? OwnerId { get; set; }

        /// <summary>
        /// Название видеозаписи.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Текст описания видеозаписи.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Длительность ролика в секундах.
        /// </summary>
        public int? Duration { get; set; }

        /// <summary>
        /// Строка, состоящая из ключа video+vid.
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// Url изображения-обложки ролика с размером 130x98px.
        /// </summary>
        public Uri Photo130 { get; set; }

        /// <summary>
        /// Url изображения-обложки ролика с размером 320x240px.
        /// </summary>
        public Uri Photo320 { get; set; }

        /// <summary>
        /// Url изображения-обложки ролика с размером 640x480px (если размер есть).
        /// </summary>
        public Uri Photo640 { get; set; }

        /// <summary>
        /// Дата добавления видеозаписи.
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        /// Количество просмотров.
        /// </summary>
        public int? ViewsCount { get; set; }

        /// <summary>
        /// Количество комментариев.
        /// </summary>
        public int? CommentsCount { get; set; }

        /// <summary>
        /// Адрес страницы с плеером, который можно использовать для воспроизведения ролика в браузере. 
        /// Поддерживается flash и html5, плеер всегда масштабируется по размеру окна.
        /// </summary>
        public Uri Player { get; set; }

        #region Методы

        internal static Video FromJson(VkResponse video)
        {
            var result = new Video();

            result.Id = video["id"];
            result.OwnerId = video["owner_id"];
            result.Title = video["title"];
            result.Description = video["description"];
            result.Duration = video["duration"];
            result.Link = video["link"];
            result.Photo130 = video["photo_130"];
            result.Photo320 = video["photo_320"];
            result.Photo320 = video["photo_640"];
            result.Date = video["date"];
            result.ViewsCount = video["views"];
            result.CommentsCount = video["comments"];
            result.Player = video["player"];

            return result;
        }

        #endregion
    }
}