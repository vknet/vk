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
		/// <inheritdoc />
		protected override string Alias => "sticker";

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
			return new Sticker
			{
				Id = response["id"] ?? response["sticker_id"],
				ProductId = response["product_id"],
				Images = response["images"].ToReadOnlyCollectionOf<Image>(x => x),
				ImagesWithBackground = response["images_with_background"].ToReadOnlyCollectionOf<Image>(x => x)
			};
		}

		/// <summary>
		/// Преобразование класса <see cref="Sticker" /> в <see cref="VkParameters" />
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns>Результат преобразования в <see cref="Sticker" /></returns>
		public static implicit operator Sticker(VkResponse response)
		{
			if (response == null)
			{
				return null;
			}

			return response.HasToken()
				? FromJson(response)
				: null;
		}
	}
}