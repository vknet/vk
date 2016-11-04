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
		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		internal static UploadServerInfo FromJson(VkResponse response)
		{
			var info = new UploadServerInfo
			{
				UploadUrl = response["upload_url"],
				AlbumId = Utilities.GetNullableLongId(response["album_id"] ?? response["aid"]),
				UserId = Utilities.GetNullableLongId(response["user_id"] ?? response["message_id"] ?? response["mid"])
			};

			return info;
		}
		#endregion
	}
}