using System;
using Newtonsoft.Json;
using VkNet.Utils;

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

	#region Методы

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static AudioPlaylistArtist FromJson(VkResponse response)
		{
			var playlistArtist = new AudioPlaylistArtist
			{
				Name = response["name"]
			};

			return playlistArtist;
		}

		/// <summary>
		/// Преобразование класса <see cref="AudioPlaylistArtist" /> в
		/// <see cref="VkParameters" />
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns>
		/// Результат преобразования в <see cref="AudioPlaylistArtist" />
		/// </returns>
		public static implicit operator AudioPlaylistArtist(VkResponse response)
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