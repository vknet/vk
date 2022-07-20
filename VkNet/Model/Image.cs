using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Копия изображения обложки.
	/// </summary>
	[Serializable]
	public class Image
	{
		/// <summary>
		/// URL копии;
		/// </summary>
		[JsonProperty("url")]
		public Uri Url { get; set; }

		/// <summary>
		/// Ширина копии;
		/// </summary>
		[JsonProperty("width")]
		public int Width { get; set; }

		/// <summary>
		/// Высота копии.
		/// </summary>
		[JsonProperty("height")]
		public int Height { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static Image FromJson(VkResponse response)
		{
			return new Image
			{
				Url = response[key: "url"],
				Width = response[key: "width"],
				Height = response[key: "height"]
			};
		}
	}
}