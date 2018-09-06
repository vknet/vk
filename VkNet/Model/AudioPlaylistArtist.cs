using System;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Информация об артисте.
	/// </summary>
	[Serializable]
	public class AudioPlaylistArtist
	{
		/// <summary>
		/// Имя исполнителя.
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }
	}
}