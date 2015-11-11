using System;
using System.Collections.Generic;
using VkNet.Utils;

namespace VkNet.Model
{
    /// <summary>
    /// Альбом для фотографий
    /// </summary>
    /// :TODO: тип данных для настроек приватности
    public class PhotoAlbum
    {
        /// <summary>
        /// Идентификатор созданного альбома
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Идентификатор фотографии, которая является обложкой альбома
        /// </summary>
        public long? ThumbId { get; set; }

        /// <summary>
        /// Идентификатор пользователя или сообщества, которому принадлежит альбом
        /// </summary>
        public long? OwnerId { get; set; }

        /// <summary>
        /// Название альбома
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Описание альбома
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Дата создания альбома
        /// </summary>
        public DateTime? Created { get; set; }

        /// <summary>
        /// Дата обновления альбома
        /// </summary>
        public DateTime? Updated { get; set; }

        /// <summary>
        /// Количество фотографий в альбоме
        /// </summary>
        public int? Size { get; set; }

        /// <summary>
        /// Настройки приватности для просмотра альбома
        /// </summary>
        public long? Privacy { get; set; }

        /// <summary>
        /// Настройки приватности для комментирования альбома
        /// </summary>
        public long? PrivacyComment
		{ get; set; }

        /// <summary>
        /// Может ли текущий пользователь добавлять фотографии в альбом
        /// </summary>
        public bool? CanUpload { get; set; }

        /// <summary>
        /// Настройки приватности для альбома в формате настроек приватности; (не приходит для системных альбомов) 
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

		/// <summary>
		/// Комментирование запрещено.
		/// </summary>
		public bool? CommentsDisabled
		{ get; set; }

		/// <summary>
		/// Загружать могут только администраторы.
		/// </summary>
		public bool UploadByAdminsOnly
		{ get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="PhotoAlbum"/> is thumb_is_last.
		/// </summary>
		/// <remarks>
		/// Получено экспериментально.
		/// </remarks>
		public bool ThumbIsLast
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
				PrivacyComment = Utilities.GetNullableLongId(response["privacy_comment"]),
		        CanUpload = response["can_upload"],
		        PrivacyView = response["privacy_view"],
		        ThumbSrc = response["thumb_src"],
				Sizes = response["sizes"].ToReadOnlyCollectionOf<PhotoSize>(x => x),
				CommentsDisabled = response["comments_disabled"],
				UploadByAdminsOnly = response["upload_by_admins_only"],
				ThumbIsLast = response["thumb_is_last"]
			};

	        return album;
        }
        #endregion
    }
}
