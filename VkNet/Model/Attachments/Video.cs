using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using VkNet.Categories;
using VkNet.Utils;

namespace VkNet.Model.Attachments
{
	/// <summary>
    /// Видеозапись пользователя или группы.
    /// </summary>
    /// <remarks>
    /// См. описание http://vk.com/dev/video_object
    /// </remarks>
    [DebuggerDisplay("Id = {Id}, Title = {Title}")]
	[Serializable]
	public class Video : MediaAttachment
    {
		/// <summary>
		/// Видеозапись пользователя или группы.
		/// </summary>
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
        /// Uri изображения-обложки ролика с размером 130x98px.
        /// </summary>
        public Uri Photo130 { get; set; }

        /// <summary>
        /// Uri изображения-обложки ролика с размером 320x240px.
        /// </summary>
        public Uri Photo320 { get; set; }

        /// <summary>
        /// Uri изображения-обложки ролика с размером 640x480px (если размер есть).
        /// </summary>
        public Uri Photo640 { get; set; }

        /// <summary>
        /// Uri изображения-обложки ролика с размером 800x450px (если размер есть).
        /// </summary>
        public Uri Photo800 { get; set; }

        /// <summary>
        /// Дата добавления видеозаписи.
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        /// Дата добавления видеозаписи пользователем или группой в формате unixtime.
        /// </summary>
        public DateTime? AddingDate { get; set; }

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
        /// Ключ доступа.
        /// </summary>
        public string AccessKey { get; set; }

        /// <summary>
        /// Поле возвращается в том случае, если видеоролик находится в процессе обработки, всегда содержит 1.
        /// </summary>
        public bool? Processing { get; set; }

        /// <summary>
        /// Поле возвращается в том случае, если видеозапись является прямой трансляцией, всегда содержит 1. Обратите внимание, в этом случае в поле duration содержится значение 0.
        /// </summary>
        public bool? Live { get; set; }

        #region Недокументированные
        /// <summary>
        /// Признак может ли текущий пользователь добавлять комментарии к видеозаписи.
        /// </summary>
        public bool? CanAdd { get; set; }

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
        /// Идентификатор видеоальбома VideoAlbum
        /// </summary>
        public long? AlbumId { get; set; }

        /// <summary>
        /// Uri, по которому необходимо выполнить загрузку видеов (см. метод VideoCategory.Save
        /// </summary>
        public Uri UploadUrl { get; set; }

        /// <summary>
        /// Отметка к видеозаписи.
        /// </summary>
        public Tag Tag { get; set; }

        /// <summary>
        /// Строка, состоящая из ключа video+vid.
        /// </summary>
        [Obsolete]
        public string Link { get; set; }

        /// <summary>
        /// Ссылки на файлы
        /// </summary>
        public VideoFiles Files { get; set; }

        /// <summary>
        /// Информация о репостах записи
        /// </summary>
        public Reposts Reposts { get; set; }

        /// <summary>
        /// Платформа
        /// </summary>
        public string Platform { get; set; }

        /// <summary>
        /// Ширина
        /// </summary>
        public int? Width { get; set; }

        /// <summary>
        /// Высота
        /// </summary>
        public int? Height { get; set; }
        
        #endregion

        #region Методы
        /// <summary>
        /// Разобрать из json.
        /// </summary>
        /// <param name="video">Ответ сервера.</param>
        /// <returns></returns>
        public static Video FromJson(VkResponse video)
        {
	        return new Video
            {
                Id = video["video_id"] ?? video["vid"] ?? video["id"],
                OwnerId = video["owner_id"],
                Title = video["title"],
                Description = video["description"],
                Duration = video["duration"],
                Photo130 = video["photo_130"],
                Photo320 = video["photo_320"],
                Photo640 = video["photo_640"],
                Photo800 = video["photo_800"],
                Date = video["date"],
                ViewsCount = video["views"],
                CommentsCount = video["comments"],
                Player = video["player"],
                AccessKey = video["access_key"],
                Processing = video["processing"],
                Live = video["live"],
                // Устаревшие или не документированные
                CanAdd = video["can_add"],
                CanComment = video["can_comment"],
                CanRepost = video["can_repost"],
                Repeat = video["repeat"],
                Likes = video["likes"],
                AlbumId = Utilities.GetNullableLongId(video["album_id"]),
                UploadUrl = video["upload_url"],
                Tag = video,
                AddingDate = video["adding_date"],
                Files = video["files"],
                Reposts = video["reposts"],
                Platform = video["platform"],
                Width = video["width"],
                Height = video["height"]
            };
        }

		/// <summary>
		/// Привести объект к строке.
		/// </summary>
		public override string ToString()
		{
			return $"video{OwnerId}_{Id}";
		}

		#endregion
    }
}