using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Объект, описывающий кликабельный стикер.
	/// </summary>
	[Serializable]
	public class ClickableStickersObject
	{
		/// <summary>
		/// Ширина оригинального фото или видео.
		/// </summary>
		[JsonProperty("original_width")]
		public int OriginalWidth { get; set; }

		/// <summary>
		/// Ширина оригинального фото или видео.
		/// </summary>
		[JsonProperty("original_height")]
		public int OriginalHeight { get; set; }

		/// <summary>
		/// Массив объектов кликабельных стикеров.
		/// </summary>
		[JsonProperty("clickable_stickers")]
		public IEnumerable<ClickableSticker> ClickableStickers { get; set; }
	}
}