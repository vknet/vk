using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Информация о пользователе/сообществе.
	/// </summary>
	[Serializable]
	public class AudioCatalogItem
	{
		/// <summary>
		/// Имя исполнителя.
		/// </summary>
		[JsonProperty("title")]
		public string Title { get; set; }

		/// <summary>
		/// Идентификатор владельца аудиозаписи.
		/// </summary>
		[JsonProperty("subtitle")]
		public string Subtitle { get; set; }

		/// <summary>
		/// Идентификатор владельца аудиозаписи.
		/// </summary>
		[JsonProperty("image")]
		public ReadOnlyCollection<AudioCatalogItemImage> Image { get; set; }

		/// <summary>
		/// Идентификатор владельца аудиозаписи.
		/// </summary>
		[JsonProperty("url")]
		public string Url { get; set; }

		/// <summary>
		/// Идентификатор владельца аудиозаписи.
		/// </summary>
		[JsonProperty("meta")]
		public AudioCatalogItemMeta Meta { get; set; }
	}
}