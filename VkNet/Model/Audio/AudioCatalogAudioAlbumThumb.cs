using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Информация о обложке альбома.
	/// </summary>
	[Serializable]
	public class AudioCatalogAudioAlbumThumb
	{
		/// <summary>
		/// Ширина.
		/// </summary>
		[JsonProperty("width")]
		public long Width { get; set; }

		/// <summary>
		/// Высота.
		/// </summary>
		[JsonProperty("height")]
		public long Height { get; set; }

		/// <summary>
		/// photo_34.
		/// </summary>
		[JsonProperty("photo_34")]
		public Uri Photo34 { get; set; }

		/// <summary>
		/// photo_68.
		/// </summary>
		[JsonProperty("photo_68")]
		public Uri Photo68 { get; set; }

		/// <summary>
		/// photo_135.
		/// </summary>
		[JsonProperty("photo_135")]
		public Uri Photo135 { get; set; }

		/// <summary>
		/// photo_270.
		/// </summary>
		[JsonProperty("photo_270")]
		public Uri Photo270 { get; set; }

		/// <summary>
		/// photo_300.
		/// </summary>
		[JsonProperty("photo_300")]
		public Uri Photo300 { get; set; }

		/// <summary>
		/// photo_600.
		/// </summary>
		[JsonProperty("photo_600")]
		public Uri Photo600 { get; set; }

		/// <summary>
		/// photo_1200.
		/// </summary>
		[JsonProperty("photo_1200")]
		public Uri Photo1200 { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static AudioCatalogAudioAlbumThumb FromJson(VkResponse response)
		{
			return new AudioCatalogAudioAlbumThumb
			{
				Width = response["width"],
				Height = response["height"],
				Photo34 = response["photo_34"],
				Photo68 = response["photo_68"],
				Photo135 = response["photo_135"],
				Photo270 = response["photo_270"],
				Photo300 = response["photo_300"],
				Photo600 = response["photo_600"],
				Photo1200 = response["photo_1200"]
			};
		}
	}
}