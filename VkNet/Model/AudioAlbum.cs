using System;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Информация об аудиоальбоме.
	/// </summary>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/audio.getAlbums
	/// </remarks>
	[Serializable]
	public class AudioAlbum
	{
		/// <summary>
		/// Идентификатор владельца альбома.
		/// </summary>
		public long? OwnerId { get; set; }

		/// <summary>
		/// Идентификатор альбома.
		/// </summary>
		public long? AlbumId { get; set; }

		/// <summary>
		/// Название альбома.
		/// </summary>
		public string Title { get; set; }

	#region Методы

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static AudioAlbum FromJson(VkResponse response)
		{
			var album = new AudioAlbum
			{
					OwnerId = response[key: "owner_id"]
					, AlbumId = response[key: "album_id"] ?? response[key: "id"]
					, Title = response[key: "title"]
			};

			return album;
		}

	#endregion
	}
}