using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.Attachments;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model
{
	/// <summary>
	/// Информация о каталоге.
	/// </summary>
	[Serializable]
	public class AudioCatalog
	{
		/// <summary>
		/// Название каталога.
		/// </summary>
		[JsonProperty("title")]
		public string Title { get; set; }

		/// <summary>
		/// Подзаголовок каталога.
		/// </summary>
		[JsonProperty("subtitle")]
		public string Subtitle { get; set; }

		/// <summary>
		/// Тип каталога.
		/// </summary>
		[JsonProperty("type")]
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public AudioCatalogType Type { get; set; }

		/// <summary>
		/// Количество каталогов.
		/// </summary>
		[JsonProperty("count")]
		public long Count { get; set; }

		/// <summary>
		/// Источник каталога.
		/// </summary>
		[JsonProperty("source")]
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public AudioCatalogSourceType Source { get; set; }

		/// <summary>
		/// Идентификатор каталога.
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; set; }

		/// <summary>
		///
		/// </summary>
		[JsonProperty("next_from")]
		public string NextFrom { get; set; }

		/// <summary>
		/// Аудиозаписи.
		/// </summary>
		[JsonProperty("audios")]
		public ReadOnlyCollection<AudioCatalogAudio> Audios { get; set; }

		/// <summary>
		/// Обложки.
		/// </summary>
		[JsonProperty("thumbs")]
		public ReadOnlyCollection<AudioCover> Thumbs { get; set; }

		/// <summary>
		/// Плейлисты.
		/// </summary>
		[JsonProperty("playlists")]
		public ReadOnlyCollection<AudioPlaylist> Playlists { get; set; }

		/// <summary>
		/// Ссылка на аудиозаписи друзей/сообщества.
		/// </summary>
		[JsonProperty("items")]
		public ReadOnlyCollection<AudioCatalogItem> Items { get; set; }
	}
}