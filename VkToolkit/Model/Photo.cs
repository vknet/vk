namespace VkToolkit.Model
{
    using System;

    using VkToolkit.Utils;

    /// <summary>
    /// Фотография.
    /// См. описание <see cref="http://vk.com/dev/photo"/> и <see cref="http://vk.com/dev/attachments_w"/> раздел 
    /// "Альбом с фотографиями".
    /// </summary>
    public class Photo
    {
        /// <summary>
        /// Идентификатор фотографии.
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Идентификатор альбома, в котором находится фотография.
        /// </summary>
        public long? AlbumId { get; set; }

        /// <summary>
        /// Идентификатор владельца фотографии.
        /// </summary>
        public long? OwnerId { get; set; }

        /// <summary>
        /// Url фотографии с максимальным размером 75x75px.
        /// </summary>
        public Uri Photo75 { get; set; }

        /// <summary>
        /// Url фотографии с максимальным размером 130x130px.
        /// </summary>
        public Uri Photo130 { get; set; }

        /// <summary>
        /// Url фотографии с максимальным размером 604x604px.
        /// </summary>
        public Uri Photo604 { get; set; }

        /// <summary>
        /// Url фотографии с максимальным размером 807x807px.
        /// </summary>
        public Uri Photo807 { get; set; }

        /// <summary>
        /// Url фотографии с максимальным размером 1280x1024px. 
        /// </summary>
        public Uri Photo1280 { get; set; }

        /// <summary>
        /// Url фотографии с максимальным размером  2560x2048px.
        /// </summary>
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

        #region Методы

        internal static Photo FromJson(VkResponse response)
        {
            var photo = new Photo();

            photo.Id = response["id"];
            photo.AlbumId = response["album_id"];
            photo.OwnerId = response["owner_id"];
            photo.Photo75 = response["photo_75"];
            photo.Photo130 = response["photo_130"];
            photo.Photo604 = response["photo_604"];
            photo.Photo807 = response["photo_807"];
            photo.Photo1280 = response["photo_1280 "];
            photo.Photo2560 = response["photo_2560"];
            photo.Width = response["width"];
            photo.Height = response["height"];
            photo.Text = response["text"];
            photo.CreateTime = response["date"];

            // из описания альбом с фотографиями
            photo.AccessKey = response["access_key"];

            return photo;
        }

        #endregion
    }
}