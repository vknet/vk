using System;
using System.Collections.Generic;
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
        public long? Privacy { get; set; }

        /// <summary>
        /// настройки приватности для комментирования альбома
        /// </summary>
        public long? CommentPrivacy { get; set; }

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

		/// <summary>
		/// Размеры фотографий.
		/// </summary>
		public IEnumerable<PhotoSize> Sizes
		{ get; set; }

		#region Methods
		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		internal static PhotoAlbum FromJson(VkResponse response)
        {
	        var album = new PhotoAlbum
	        {
		        Id = response["aid"] ?? response["id"],
		        ThumbId = Utilities.GetNullableLongId(response["thumb_id"]),
		        OwnerId = Utilities.GetNullableLongId(response["owner_id"]),
		        Title = response["title"],
		        Description = response["description"],
		        Created = response["created"],
		        Updated = response["updated"],
		        Size = response["size"],
		        Privacy = Utilities.GetNullableLongId(response["privacy"]),
		        CommentPrivacy = Utilities.GetNullableLongId(response["comment_privacy"]),
		        CanUpload = response["can_upload"],
		        PrivacyView = response["privacy_view"],
		        ThumbSrc = response["thumb_src"],
				Sizes = response["sizes"].ToReadOnlyCollectionOf<PhotoSize>(x => x)
			};

	        return album;
        }
        #endregion
    }
}
