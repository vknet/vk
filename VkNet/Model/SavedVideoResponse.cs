using System;
using System.Diagnostics;
using Newtonsoft.Json;

namespace VkNet.Model
{
	public class SavedVideoResponse
	{
		/// <summary>
		/// Ссылка по которой требуется перейти (GET запрос), чтобы подтвердить загрузку видео с внешнего источника
		/// </summary>
		[JsonProperty("upload_url")]
		public string UploadUrl { get; set; }

		/// <summary>
		/// Идентификатор видеозаписи
		/// </summary>
		[JsonProperty("vid")]
		public int Vid { get; set; }

		/// <summary>
		/// Идентификатор владельца видеозаписи
		/// </summary>
		[JsonProperty("owner_id")]
		public int OwnerId { get; set; }

		/// <summary>
		/// Название видеозаписи
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Описание видеозаписи
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Ключ доступа
		/// </summary>
		[JsonProperty("access_key")]
		public string AccessKey { get; set; }
	}
}