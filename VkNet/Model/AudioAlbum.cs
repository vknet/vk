using System;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Информация об аудиоальбоме.
	/// </summary>
	[Serializable]
	public class AudioAlbum
	{
		/// <summary>
		/// Идентификатор альбома.
		/// </summary>
		[JsonProperty("id")]
		public long Id { get; set; }

		/// <summary>
		/// Идентификатор владельца альбома (пользователь или сообщество).
		/// </summary>
		[JsonProperty("owner_id")]
		public long OwnerId { get; set; }

		/// <summary>
		/// Название альбома.
		/// </summary>
		[JsonProperty("title")]
		public string Title { get; set; }

		/// <summary>
		/// Обложка альбома.
		/// </summary>
		[JsonProperty("thumb")]
		public AudioCover Cover { get; set; }

		/// <summary>
		/// Ключ доступа.
		/// </summary>
		[JsonProperty("access_key")]
		public string AccessKey { get; set; }
	}
}