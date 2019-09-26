using System;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Объект, описывающий размер обложки видео.
	/// См. описание https://vk.com/dev/objects/video_image
	/// </summary>
	[Serializable]
	public class VideoImage
	{
		/// <summary>
		/// URL-адрес изображения.
		/// </summary>
		[JsonProperty("url")]
		public Uri Url { get; set; }

		/// <summary>
		/// Ширина изображения.
		/// </summary>
		[JsonProperty("width")]
		public ulong Width { get; set; }

		/// <summary>
		/// Высота изображения.
		/// </summary>
		[JsonProperty("height")]
		public ulong Height { get; set; }

		/// <summary>
		/// <c>true</c>, если изображение имеет черные поля.
		/// </summary>
		[JsonProperty("with_padding")]
		public bool WithPadding { get; set; }
	}
}