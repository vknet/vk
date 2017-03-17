using System;
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
    /// См. описание <see href="http://vk.com/dev/video_object"/>.
    /// </remarks>
    [DebuggerDisplay("Id = {Id}, Title = {Title}")]
	[DataContract]
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
        /// Строка, состоящая из ключа video+vid.
        /// </summary>
        public string Link { get; set; }

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
        /// Uri, по которому необходимо выполнить загрузку видеов (см. метод <see cref="VideoCategory.Save"/>).
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

		/// <summary>
		/// Поле возвращается в том случае, если видеозапись является прямой трансляцией, всегда содержит 1. Обратите внимание, в этом случае в поле duration содержится значение 0.
		/// </summary>
		public bool? Live { get; set; }

		/// <summary>
		/// Поле возвращается в том случае, если видеоролик находится в процессе обработки, всегда содержит 1.
		/// </summary>
		public bool? Processing { get; set; }

		/// <summary>
		/// Дата добавления видеозаписи пользователем или группой в формате unixtime.
		/// </summary>
		public DateTime? AddingDate { get; set; }
		#region Методы
		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="video">Ответ сервера.</param>
		/// <returns></returns>
		public static Video FromJson(VkResponse video)
        {
	        var result = new Video
	        {
		        Id = video["video_id"] ?? video["vid"] ?? video["id"],
		        OwnerId = video["owner_id"],
		        Title = video["title"],
		        Description = video["description"],
		        Duration = video["duration"],
		        Link = video["link"],
		        Photo130 = video["photo_130"],
		        Photo320 = video["photo_320"],
		        Photo640 = video["photo_640"],
                Photo800 = video["photo_800"],
                Date = video["date"],
		        ViewsCount = video["views"],
		        CommentsCount = video["comments"],
		        Player = video["player"],
		        CanComment = video["can_comment"],
		        CanRepost = video["can_repost"],
		        Repeat = video["repeat"],
		        Likes = video["likes"],
		        AlbumId = Utilities.GetNullableLongId(video["album_id"]),
		        UploadUrl = video["upload_url"],
		        AccessKey = video["access_key"],
		        Tag = video,
				Live = video["live"],
				Processing = video["processing"],
				AddingDate = video["adding_date"]
			};

	        return result;
        }

		public override string ToString()
		{
			return $"video{OwnerId}_{Id}";
		}

		#endregion
    }
}