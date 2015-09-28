namespace VkNet.Model.Attachments
{
    using System;

    using Utils;

	/// <summary>
    /// Фотография.
    /// </summary>
    /// <remarks>
    /// См. описание <see href="http://vk.com/dev/photo"/> и <see href="http://vk.com/dev/attachments_w"/> раздел "Альбом с фотографиями".
    /// </remarks>
    public class Photo : MediaAttachment
    {
		static Photo()
		{
			RegisterType(typeof (Photo), "photo");
		}

        /// <summary>
        /// Идентификатор альбома, в котором находится фотография.
        /// </summary>
        public long? AlbumId { get; set; }

        /// <summary>
        /// Url фотографии с максимальным размером.
        /// </summary>
        public Uri BigPhotoSrc { get; set; }

        /// <summary>
        /// Url фотографии с минимальным размером.
        /// </summary>
        public Uri SmallPhotoSrc { get; set; }

        /// <summary>
        /// Url фотографии с максимальным размером 75x75px.
        /// </summary>
        [Obsolete]
        public Uri Photo75 { get; set; }

        /// <summary>
        /// Url фотографии с максимальным размером 130x130px.
        /// </summary>
        [Obsolete]
        public Uri Photo130 { get; set; }

        /// <summary>
        /// Url фотографии с максимальным размером 604x604px.
        /// </summary>
        [Obsolete]
        public Uri Photo604 { get; set; }

        /// <summary>
        /// Url фотографии с максимальным размером 807x807px.
        /// </summary>
        [Obsolete]
        public Uri Photo807 { get; set; }

        /// <summary>
        /// Url фотографии с максимальным размером 1280x1024px. 
        /// </summary>
        [Obsolete]
        public Uri Photo1280 { get; set; }

        /// <summary>
        /// Url фотографии с максимальным размером  2560x2048px.
        /// </summary>
        [Obsolete]
        public Uri Photo2560 { get; set; }

        /// <summary>
        /// Ширина оригинала фотографии в пикселах
        /// </summary>
        public int? Width { get; set; }

        /// <summary>
        /// Высота оригинала фотографии в пикселах. 
        /// </summary>
        public int? Height { get; set; }

        /// <summary>
        /// Текст описания фотографии. 
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Дата добавления фотографии.
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// Ключ доступа.
        /// </summary>
        public string AccessKey { get; set; }

        /// <summary>
        /// Идентификатор пользователя, загрузившего фото (если фотография размещена в сообществе). Для фотографий, размещенных от имени сообщества.
        /// </summary>
        public long? UserId { get; set; }

        /// <summary>
        /// Идентификатор записи, у которой данная фотография является прикреплением???
        /// </summary>
        public long? PostId { get; set; }

        /// <summary>
        /// идентификатор пользователя, сделавшего отметку
        /// </summary>
        public long? PlacerId { get; set; }

        /// <summary>
        /// дата создания отметки
        /// </summary>
        public DateTime? TagCreated { get; set; }

        /// <summary>
        /// идентификатор отметки
        /// </summary>
        public long? TagId { get; set; }

        /// <summary>
        /// Лайки
        /// </summary>
        public Likes Likes { get; set; }

        /// <summary>
        /// Возможность комментирования фотографии
        /// </summary>
        public bool? CanComment { get; set; }

        /// <summary>
        /// Комментарии
        /// </summary>
        public Comments Comments { get; set; }

        /// <summary>
        /// Теги
        /// </summary>
        public Tags Tags { get; set; }
                                          
	    /// <summary>
	    /// Географическая широта отметки, заданная в градусах
	    /// </summary>
	    public double? Latitude;

        /// <summary>
        /// Географическая долгота отметки, заданная в градусах
        /// </summary>
	    public double? Longitude;

        #region Методы

        internal static Photo FromJson(VkResponse response)
        {
            var photo = new Photo();

            photo.Id = response["pid"] ?? response["id"];
            photo.AlbumId = response["album_id"] ?? response["aid"];
            photo.OwnerId = response["owner_id"];
            photo.Photo75 = response["photo_75"] ?? response["src_small"];
            photo.Photo130 = response["photo_130"] ?? response["src"];
            photo.Photo604 = response["photo_604"] ?? response["src_big"];
            photo.Photo807 = response["photo_807"] ?? response["src_xbig"];
            photo.Photo1280 = response["photo_1280"] ?? response["src_xxbig"];
            photo.Photo2560 = response["photo_2560"] ?? response["src_xxxbig"];
            photo.Width = response["width"];
            photo.Height = response["height"];
            photo.Text = response["text"];
            photo.CreateTime = response["created"];

            photo.UserId = Utilities.GetNullableLongId(response["user_id"]);
            photo.PostId = Utilities.GetNullableLongId(response["post_id"]);

            // из описания альбом с фотографиями
            photo.AccessKey = response["access_key"];

            photo.PlacerId = Utilities.GetNullableLongId(response["placer_id"]);
            photo.TagCreated = response["tag_created"];
            photo.TagId = response["tag_id"];

            photo.Likes = response["likes"];
            photo.Comments = response["comments"];
            photo.CanComment = response["can_comment"];
            photo.Tags = response["tags"];

            photo.SmallPhotoSrc = response["src_small"];
                                                        
            photo.Latitude = response["lat"];
            photo.Longitude = response["long"];

            return photo;
        }

        #endregion
    }
}