using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Обложка аудиоальбома.
	/// </summary>
	[Serializable]
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

	#region Методы

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static AudioCover FromJson(VkResponse response)
		{
			var album = new AudioCover
			{
				Photo34 = response["photo_34"],
				Photo68 = response["photo_68"],
				Photo135 = response["photo_135"],
				Photo270 = response["photo_270"],
				Photo300 = response["photo_300"],
				Photo600 = response["photo_600"],
				Width = response["width"],
				Height = response["height"]
			};

			return album;
		}

		/// <summary>
		/// Преобразование класса <see cref="AudioCover" /> в
		/// <see cref="VkParameters" />
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> Результат преобразования в <see cref="AudioCover" /> </returns>
		public static implicit operator AudioCover(VkResponse response)
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