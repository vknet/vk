using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Обложка аудиоальбома.
	/// </summary>
	public class AudioCover
	{
		/// <summary>
		/// Uri обложки с максимальным размером 34x34.
		/// </summary>
		[JsonProperty("photo_34")]
		public string Photo34 { get; set; }

		/// <summary>
		/// Uri обложки с максимальным размером 68x68.
		/// </summary>
		[JsonProperty("photo_68")]
		public string Photo68 { get; set; }

		/// <summary>
		/// Uri обложки с максимальным размером 135x135.
		/// </summary>
		[JsonProperty("photo_135")]
		public string Photo135 { get; set; }

		/// <summary>
		/// Uri обложки с максимальным размером 270x270.
		/// </summary>
		[JsonProperty("photo_270")]
		public string Photo270 { get; set; }

		/// <summary>
		/// Uri обложки с максимальным размером 300x300.
		/// </summary>
		[JsonProperty("photo_300")]
		public string Photo300 { get; set; }

		/// <summary>
		/// Uri обложки с максимальным размером 600x600.
		/// </summary>
		[JsonProperty("photo_600")]
		public string Photo600 { get; set; }

		/// <summary>
		/// Ширина изображения обложки.
		/// </summary>
		[JsonProperty("width")]
		public long Width { get; set; }

		/// <summary>
		/// Высота изображения обложки.
		/// </summary>
		[JsonProperty("height")]
		public long Height { get; set; }
	}
}