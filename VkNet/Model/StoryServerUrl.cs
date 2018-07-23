using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Данные для загрузки фотографии/видео в историю.
	/// </summary>
	[Serializable]
    public class StoryServerUrl
    {
		/// <summary>
		/// Адрес сервера для загрузки файла.
		/// </summary>
		[JsonProperty("upload_url")]
		public Uri UploadUrl { get; set; }
		/// <summary>
		/// Идентификаторы пользователей, которые могут видеть историю.
		/// </summary>
		[JsonProperty("user_ids")]
		public IEnumerable<long> UsersIds { get; set; }
    }
}
