using System;
using Newtonsoft.Json;
using VkNet.Utils;

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
		
	#region Методы

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static AudioPlaylistFollower FromJson(VkResponse response)
		{
			var playlistFollower = new AudioPlaylistFollower
			{
				OwnerId = response["owner_id"],
				PlaylistId = response["playlist_id"]
			};

			return playlistFollower;
		}

		/// <summary>
		/// Преобразование класса <see cref="AudioPlaylistFollower" /> в
		/// <see cref="VkParameters" />
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> Результат преобразования в <see cref="AudioPlaylistFollower" /> </returns>
		public static implicit operator AudioPlaylistFollower(VkResponse response)
		{
			if (response == null)
			{
				return null;
			}

			return response.HasToken()
				? FromJson(response)
				: null;
		}

	#endregion
	}
}