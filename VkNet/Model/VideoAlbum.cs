using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Utils;

namespace VkNet.Model
{
    /// <summary>
    /// Видеоальбом.
    /// </summary>
    /// <remarks>
    /// Страница документации ВКонтакте http://vk.com/dev/video.getAlbums
    /// </remarks>
    [Serializable]
    public class VideoAlbum
    {
        /// <summary>
        /// Идентификатор альбома.
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Идентификатор владельца альбома.
        /// </summary>
        public long? OwnerId { get; set; }

        /// <summary>
        /// Название альбома.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Количество видеозаписей в альбоме.
        /// </summary>
        public long? Count { get; set; }

        /// <summary>
        /// URL изображения предпросмотра альбома шириной в 160 пикселов.
        /// </summary>
        public string Photo160 { get; set; }

        /// <summary>
        /// URL изображения предпросмотра альбома шириной в 320 пикселов.
        /// </summary>
        public string Photo320 { get; set; }
	    
	    /// <summary>
	    /// время последнего обновления в формате unixtime
	    /// </summary>
	    [JsonProperty("updated_time")]
	    [JsonConverter(typeof(UnixDateTimeConverter))]
	    public DateTime? UpdatedTime { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		public static VideoAlbum FromJson(VkResponse response)
		{
			var album = new VideoAlbum
			{
				Id = Utilities.GetNullableLongId(response["id"]),
				OwnerId = response["owner_id"],
				Title = response["title"],
				Count = Utilities.GetNullableLongId(response["count"]),
				Photo160 = response["photo_160"],
				Photo320 = response["photo_320"],
				UpdatedTime = response["updated_time"]
			};

			return album;
		}
	}
}