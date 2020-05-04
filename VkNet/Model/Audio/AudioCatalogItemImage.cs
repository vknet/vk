using System;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Информация о фото пользователя/сообщества
	/// </summary>
	[Serializable]
	public class AudioCatalogItemImage
	{
		/// <summary>
		/// Ширина.
		/// </summary>
		[JsonProperty("width")]
		public long Width { get; set; }

		/// <summary>
		/// Высота.
		/// </summary>
		[JsonProperty("height")]
		public long Height { get; set; }

		/// <summary>
		/// Ссылка фото пользователя/сообщества.
		/// </summary>
		[JsonProperty("url")]
		public Uri Url { get; set; }
	}
}