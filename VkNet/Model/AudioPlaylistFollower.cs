using System;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Подписчик плейлиста.
	/// </summary>
	[Serializable]
	public class AudioPlaylistFollower
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
	}
}