using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;

namespace VkNet.Model
{
    /// <summary>
    /// Альбом для фотографий
    /// </summary>
    [Serializable]
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
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? Created { get; set; }

        /// <summary>
        /// Дата обновления альбома
        /// </summary>
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? Updated { get; set; }

        /// <summary>
        /// Количество фотографий в альбоме
        /// </summary>
        public int? Size { get; set; }

		/// <summary>
		/// Настройки приватности для альбома в формате настроек приватности; (не приходит для системных альбомов)
		/// </summary>
		public ReadOnlyCollection<Privacy> PrivacyView
		{ get; set; }

        /// <summary>
        /// Настройки приватности для комментирования альбома
        /// </summary>
        public ReadOnlyCollection<Privacy> PrivacyComment
		{ get; set; }

        /// <summary>
        /// Может ли текущий пользователь добавлять фотографии в альбом
        /// </summary>
        public bool? CanUpload { get; set; }

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
		/// Gets or sets a value indicating whether this PhotoAlbum
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
		public static PhotoAlbum FromJson(VkResponse response)
        {
			VkResponseArray privacy = response["privacy_view"];
			VkResponseArray privacyComment = response["privacy_comment"];
            return new PhotoAlbum
	        {
		        Id = response["album_id"] ?? response["aid"] ?? response["id"],
		        ThumbId = Utilities.GetNullableLongId(response["thumb_id"]),
		        OwnerId = Utilities.GetNullableLongId(response["owner_id"]),
		        Title = response["title"],
		        Description = response["description"],
		        Created = response["created"],
		        Updated = response["updated"],
		        Size = response["size"],
				PrivacyView = privacy.ToReadOnlyCollectionOf<Privacy>(x => x),
				PrivacyComment = privacyComment.ToReadOnlyCollectionOf<Privacy>(x => x),
		        CanUpload = response["can_upload"],
		        ThumbSrc = response["thumb_src"],
				Sizes = response["sizes"].ToReadOnlyCollectionOf<PhotoSize>(x => x),
				CommentsDisabled = response["comments_disabled"],
				UploadByAdminsOnly = response["upload_by_admins_only"],
				ThumbIsLast = response["thumb_is_last"]
			};
        }
        #endregion
    }
}
