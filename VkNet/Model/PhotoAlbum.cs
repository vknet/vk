using System;
using VkNet.Utils;

namespace VkNet.Model
{
    /// <summary>
    /// Альбом для фотографий
    /// </summary>
    public class PhotoAlbum
    {
        /// <summary>
        /// идентификатор созданного альбома
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// идентификатор фотографии, которая является обложкой альбома
        /// </summary>
        public long? ThumbId { get; set; }

        /// <summary>
        /// идентификатор пользователя или сообщества, которому принадлежит альбом
        /// </summary>
        public long? OwnerId { get; set; }

        /// <summary>
        /// название альбома
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// описание альбома
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// дата создания альбома
        /// </summary>
        public DateTime? Created { get; set; }

        /// <summary>
        /// дата обновления альбома
        /// </summary>
        public DateTime? Updated { get; set; }

        /// <summary>
        /// количество фотографий в альбоме
        /// </summary>
        public int? Size { get; set; }

        /// <summary>
        /// настройки приватности для просмотра альбома
        /// </summary>
        public string Privacy { get; set; }

        /// <summary>
        /// настройки приватности для комментирования альбома
        /// </summary>
        public string CommentPrivacy { get; set; }

        /// <summary>
        /// может ли текущий пользователь добавлять фотографии в альбом
        /// </summary>
        public bool? CanUpload { get; set; }

        /// <summary>
        /// настройки приватности для альбома в формате настроек приватности; (не приходит для системных альбомов) 
        /// </summary>
        public string PrivacyView { get; set; }

        /// <summary>
        /// Адрес на изображение с предпросмотром
        /// </summary>
        public string ThumbSrc { get; set; }

        #region Methods
        internal static PhotoAlbum FromJson(VkResponse response)
        {
            var album = new PhotoAlbum();

            album.Id = response["id"];
            album.ThumbId = Utilities.GetNullableLongId(response["thumb_id"]);
            album.OwnerId = Utilities.GetNullableLongId(response["owner_id"]);
            album.Title = response["title"];
            album.Description = response["description"];
            album.Created = response["created"];
            album.Updated = response["updated"];
            album.Size = response["size"];
            album.Privacy = response["privacy"];
            album.CommentPrivacy = response["comment_privacy"];
            album.CanUpload = response["can_upload"];
            album.PrivacyView = response["privacy_view"];
            album.ThumbSrc = response["thumb_src"];

            return album;
        }
        #endregion
    }
}