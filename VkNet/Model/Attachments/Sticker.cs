using System;
using System.Collections.Generic;
using VkNet.Utils;

namespace VkNet.Model.Attachments
{
	/// <summary>
	/// Стикер.
	/// </summary>
	[Serializable]
	public class Sticker : MediaAttachment
	{
		/// <summary>
		/// Стикер.
		/// </summary>
		static Sticker()
		{
			RegisterType(type: typeof(Sticker), match: "sticker");
		}

		/// <summary>
		/// Идентификатор набора.
		/// </summary>
		public long? ProductId { get; set; }

		/// <summary>
		/// Изображения для стикера (с прозрачным фоном).
		/// </summary>
		public IEnumerable<Image> Images { get; set; }

		/// <summary>
		/// Изображения для стикера (с непрозрачным фоном).
		/// </summary>
		public IEnumerable<Image> ImagesWithBackground { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static Sticker FromJson(VkResponse response)
		{
			var sticker = new Sticker
			{
					Id = response[key: "id"] ?? response[key: "sticker_id"]
					, ProductId = response[key: "product_id"]
					, Images = response[key: "images"].ToReadOnlyCollectionOf<Image>(selector: x => x)
					, ImagesWithBackground = response[key: "images_with_background"].ToReadOnlyCollectionOf<Image>(selector: x => x)
			};

			return sticker;
		}
	}
}