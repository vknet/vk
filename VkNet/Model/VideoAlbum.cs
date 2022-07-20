using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Infrastructure;
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
		[JsonProperty("id")]
		public long? Id { get; set; }

		/// <summary>
		/// Идентификатор владельца альбома.
		/// </summary>
		[JsonProperty("owner_id")]
		public long? OwnerId { get; set; }

		/// <summary>
		/// Название альбома.
		/// </summary>
		[JsonProperty("title")]
		public string Title { get; set; }

		/// <summary>
		/// Количество видеозаписей в альбоме.
		/// </summary>
		[JsonProperty("count")]
		public long? Count { get; set; }

		/// <summary>
		/// URL изображения предпросмотра альбома шириной в 160 пикселов.
		/// </summary>
		[Obsolete("Это свойство устарело в версии api 5.101. Используйте свойство IEnumerable<VideoImage> Image")]
		[JsonProperty("photo_160")]
		public string Photo160 { get; set; }

		/// <summary>
		/// URL изображения предпросмотра альбома шириной в 320 пикселов.
		/// </summary>
		[Obsolete("Это свойство устарело в версии api 5.101. Используйте свойство IEnumerable<VideoImage> Image")]
		[JsonProperty("photo_320")]
		public string Photo320 { get; set; }

		/// <summary>
		/// Список изображений обложки альбома.
		/// </summary>
		[JsonProperty("image")]
		public IEnumerable<VideoImage> Image { get; set; }

		/// <summary>
		/// время последнего обновления в формате unixtime
		/// </summary>
		[JsonProperty("updated_time")]
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime? UpdatedTime { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static VideoAlbum FromJson(VkResponse response)
		{
			return response != null
				? JsonConvert.DeserializeObject<VideoAlbum>(response.ToString(), JsonConfigure.JsonSerializerSettings)
				: null;
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator VideoAlbum(VkResponse response)
		{
			return response.HasToken()
				? FromJson(response)
				: null;
		}
	}
}