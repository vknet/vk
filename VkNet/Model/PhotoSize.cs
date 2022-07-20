using System;
using Newtonsoft.Json;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model
{
	/// <summary>
	/// Формат описания размеров фотографи.
	/// </summary>
	[Serializable]
	public class PhotoSize
	{
		/// <summary>
		/// Uri копии изображения.
		/// </summary>
		[JsonProperty("src")]
		public Uri Src { get; set; }

		/// <summary>
		/// Uri копии изображения.
		/// </summary>
		[JsonProperty("url")]
		public Uri Url { get; set; }

		/// <summary>
		/// Ширина копии в пикселах.
		/// </summary>
		[JsonProperty("width")]
		public ulong Width { get; set; }

		/// <summary>
		/// Высота копии в пикселах.
		/// </summary>
		[JsonProperty("height")]
		public ulong Height { get; set; }

		/// <summary>
		/// Обозначение размера и пропорций копии.
		/// </summary>
		[JsonProperty("type")]
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public PhotoSizeType Type { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static PhotoSize FromJson(VkResponse response)
		{
			var photoSize = new PhotoSize
			{
				Src = response["src"],
				Url = response["url"],
				Width = response[key: "width"],
				Height = response[key: "height"],
				Type = response[key: "type"]
			};

			return photoSize;
		}
	}
}