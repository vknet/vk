using System;
using System.Diagnostics;
using VkNet.Categories;
using VkNet.Utils;

namespace VkNet.Model.Attachments
{
	/// <summary>
    /// Видеозапись пользователя или группы.
    /// </summary>
    /// <remarks>
    /// См. описание <see href="http://vk.com/dev/video_object"/>.
    /// </remarks>
    [DebuggerDisplay("Id = {Id}, Title = {Title}")]
    public class Video : MediaAttachment
    {
		static Video()
		{
			RegisterType(typeof(Video), "video");
		}

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

        /// <summary>
        /// Признак может ли текущий пользователь добавлять комментарии к видеозаписи.
        /// </summary>
        public bool? CanComment { get; set; }

        /// <summary>
        /// Признак может ли текущий пользователь сделать репост данной видеозаписи.
        /// </summary>
        public bool? CanRepost { get; set; }

        /// <summary>
        /// Информация о лайках к видеозаписи.
        /// </summary>
        public Likes Likes { get; set; }

        /// <summary>
        /// Признак является ли видеозапись зацикленной.
        /// </summary>
        public bool? Repeat { get; set; }

        /// <summary>
        /// Идентификатор видеоальбома <see cref="VideoAlbum"/>, к которому относится видеозапись.
        /// </summary>
        public long? AlbumId { get; set; }

        /// <summary>
        /// Url, по которому необходимо выполнить загрузку видеов (см. метод <see cref="VideoCategory.Save"/>).
        /// </summary>
        public Uri UploadUrl { get; set; }

        /// <summary>
        /// Ключ доступа.
        /// </summary>
        public string AccessKey { get; set; }

        /// <summary>
        /// Отметка к видеозаписи.
        /// </summary>
        public Tag Tag { get; set; }

        #region Методы

        internal static Video FromJson(VkResponse video)
        {
            var result = new Video();

            result.Id = video["id"] ?? video["video_id"];
            result.OwnerId = video["owner_id"];
            result.Title = video["title"];
            result.Description = video["description"];
            result.Duration = video["duration"];
            result.Link = video["link"];
            result.Photo130 = video["photo_130"];
            result.Photo320 = video["photo_320"];
            result.Photo640 = video["photo_640"];
            result.Date = video["date"];
            result.ViewsCount = video["views"];
            result.CommentsCount = video["comments"];
            result.Player = video["player"];

            result.CanComment = video["can_comment"];
            result.CanRepost = video["can_repost"];
            result.Repeat = video["repeat"];
            result.Likes = video["likes"];
            result.AlbumId = Utilities.GetNullableLongId(video["album_id"]);
            result.UploadUrl = video["upload_url"];
            result.AccessKey = video["access_key"];

            result.Tag = video;

            return result;
        }

        #endregion
    }
}