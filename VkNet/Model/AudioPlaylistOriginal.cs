using System;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Неизвестно.
	/// </summary>
	[Serializable]
	public class AudioPlaylistOriginal
	{
		/// <summary>
		/// Идентификатор владельца.
		/// </summary>
		[JsonProperty("owner_id")]
		public long OwnerId { get; set; }

		/// <summary>
		/// Идентификатор плейлиста.
		/// </summary>
		[JsonProperty("playlist_id")]
		public long PlaylistId { get; set; }

		/// <summary>
		/// Ключ доступа.
		/// </summary>
		[JsonProperty("access_key")]
		public string AccessKey { get; set; }
	}
}