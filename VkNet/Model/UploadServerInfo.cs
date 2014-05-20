namespace VkNet.Model
{
    using Utils;

    /// <summary>
    /// Адрес сервера для загрузки фотографий
    /// </summary>
    public class UploadServerInfo
    {
        /// <summary>
        /// Адрес для загрузки фотографий
        /// </summary>
        public string UploadUrl { get; set; }

        /// <summary>
        /// Идентификатор альбома, в который будет загружена фотография
        /// </summary>
        public long? AlbumId { get; set; }

        /// <summary>
        /// Идентификатор пользователя, от чьего имени будет загружено фото
        /// </summary>
        public long? UserId { get; set; }

        #region Methods
        internal static UploadServerInfo FromJson(VkResponse response)
        {
            var info = new UploadServerInfo();

            info.UploadUrl = response["upload_url"];
            info.AlbumId = Utilities.GetNullableLongId(response["album_id"] ?? response["aid"]);
            info.UserId = Utilities.GetNullableLongId(response["user_id"] ?? response["mid"]);

            return info;
        }
        #endregion
    }
}