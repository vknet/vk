using System;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
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
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? Date { get; set; }

        /// <summary>
        /// Дата добавления видеозаписи пользователем или группой в формате unixtime.
        /// </summary>
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? AddingDate { get; set; }

        /// <summary>
        /// Количество просмотров.
        /// </summary>
        public int? Views { get; set; }

        /// <summary>
        /// Количество комментариев.
        /// </summary>
        public int? Comments { get; set; }

        /// <summary>
        /// Адрес страницы с плеером, который можно использовать для воспроизведения ролика в браузере.
        /// Поддерживается flash и html5, плеер всегда масштабируется по размеру окна.
        /// </summary>
        public Uri Player { get; set; }

	    /// <summary>
	    /// Платформа
	    /// </summary>
	    public string Platform { set; get; }

	    /// <summary>
	    /// поле возвращается, если пользователь может редактировать видеозапись, всегда содержит 1.
	    /// </summary>
	    [JsonProperty("can_edit")]
	    public bool? CanEdit { get; set; }

	    /// <summary>
	    /// Признак может ли текущий пользователь добавлять комментарии к видеозаписи.
	    /// </summary>
	    public bool? CanAdd { get; set; }

	    /// <summary>
	    /// поле возвращается, если видеозапись приватная (например, была загружена в личное сообщение), всегда содержит 1.
	    /// </summary>
	    [JsonProperty("is_private")]
	    public bool? IsPrivate { get; set; }

	    /// <summary>
	    /// Ключ доступа.
	    /// </summary>
	    public string AccessKey { set; get; }

	    /// <summary>
	    /// Поле возвращается в том случае, если видеоролик находится в процессе обработки, всегда содержит 1.
	    /// </summary>
	    public bool? Processing { set; get; }

	    /// <summary>
        /// Поле возвращается в том случае, если видеозапись является прямой трансляцией, всегда содержит 1. Обратите внимание, в этом случае в поле duration содержится значение 0.
        /// </summary>
        public bool? Live { get; set; }

	    /// <summary>
	    /// (для live = 1). Поле свидетельствует о том, что трансляция скоро начнётся.
	    /// </summary>
	    [JsonProperty("upcoming")]
	    public bool? Upcoming { get; set; }
	    #region Недокументированные

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
        /// Ссылки на файлы
        /// </summary>
        public VideoFiles Files { get; set; }

	    /// <summary>
        /// Информация о репостах записи
        /// </summary>
        public Reposts Reposts { get; set; }

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
        /// <param name="response">Ответ сервера.</param>
        /// <returns></returns>
        public static Video FromJson(VkResponse response)
        {
	        return new Video
            {
                Id = response["video_id"] ?? response["vid"] ?? response["id"],
                OwnerId = response["owner_id"],
                Title = response["title"],
                Description = response["description"],
                Duration = response["duration"],
                Photo130 = response["photo_130"],
                Photo320 = response["photo_320"],
                Photo640 = response["photo_640"],
                Photo800 = response["photo_800"],
                Date = response["date"],
                Views = response["views"],
                Comments = response["comments"],
                Player = response["player"],
                AccessKey = response["access_key"],
                Processing = response["processing"],
                Live = response["live"],
                // Устаревшие или не документированные
                CanAdd = response["can_add"],
                CanComment = response["can_comment"],
                CanRepost = response["can_repost"],
                Repeat = response["repeat"],
                Likes = response["likes"],
                AlbumId = Utilities.GetNullableLongId(response["album_id"]),
                UploadUrl = response["upload_url"],
                Tag = response,
                AddingDate = response["adding_date"],
                Files = response["files"],
                Reposts = response["reposts"],
                Platform = response["platform"],
                Width = response["width"],
                Height = response["height"],
	            CanEdit = response["can_edit"],
	            IsPrivate = response["is_private"],
	            Upcoming = response["upcoming"],
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