using System;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Жанр плейлиста.
	/// </summary>
	[Serializable]
	public class AudioPlaylistGenre
	{
		/// <summary>
		/// Идентификатор жанра.
		/// </summary>
		[JsonProperty("id")]
		public long Id { get; set; }

		/// <summary>
		/// Название жанра.
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }
	}
}