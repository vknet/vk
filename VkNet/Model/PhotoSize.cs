﻿using System;
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
		[Obsolete("Используйте поле url. Данное поле будет удалено в релизе 2.0.0")]
		public Uri Src => Url;

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
				Url = response["url"],
				Width = response[key: "width"],
				Height = response[key: "height"],
				Type = response[key: "type"]
			};

			return photoSize;
		}
	}
}