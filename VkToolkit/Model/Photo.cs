using System;

using VkToolkit.Utils;

namespace VkToolkit.Model
{
    /// <summary>
    /// Фотография.
    /// </summary>
    public class Photo
    {
        /// <summary>
        /// Идентификатор изображения.
        /// </summary>
        public long? Id { get; set; }
        /// <summary>
        /// Идентификатор альбома, в котором находится изображение.
        /// </summary>
        public long? AlbumId { get; set; }
        /// <summary>
        /// Идентификатор владельца альбома.
        /// </summary>
        public long? OwnerId { get; set; }
        /// <summary>
        /// TODO: Неизвестно ???
        /// </summary>
        public long? UserId { get; set; }
        /// <summary>
        /// Url фотографии.
        /// </summary>
        public Uri Src { get; set; }
        /// <summary>
        /// Url маленькой фотографии.
        /// </summary>
        public Uri SrcSmall { get; set; }
        /// <summary>
        /// Url большой картинки фотографии.
        /// </summary>
        public Uri SrcBig { get; set; }
        /// <summary>
        /// Url очень большой фотографии.
        /// </summary>
        public Uri SrcXBig { get; set; }
        /// <summary>
        /// Url самой большой фотографии.
        /// </summary>
        public Uri SrcXxBig { get; set; }
        /// <summary>
        /// Время создания превьюшки.
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Время создания фотографии.
        /// </summary>
        public DateTime? Created { get; set; }
        /// <summary>
        /// Ширина изображения.
        /// </summary>
        public int? Width { get; set; }
        /// <summary>
        /// Высота изображения.
        /// </summary>
        public int? Height { get; set; }
        /// <summary>
        /// Ключ доступа к фотографии.
        /// </summary>
        public string AccessKey { get; set; }

        internal static Photo FromJson(VkResponse response)
        {
            var photo = new Photo();

            photo.Id = response["pid"];
            photo.AlbumId = response["aid"];
            photo.OwnerId = response["owner_id"];
            photo.UserId = response["user_id"];
            photo.Text = response["text"];
            photo.Width = response["width"];
            photo.Height = response["height"];
            photo.AccessKey = response["access_key"];
            photo.Src = response["src"];
            photo.SrcSmall = response["src_small"];
            photo.SrcBig = response["src_big"];
            photo.Created = response["created"];
            photo.SrcXBig = response["src_xbig"];
            photo.SrcXxBig = response["src_xxbig"];

            return photo;
        }
    }
}