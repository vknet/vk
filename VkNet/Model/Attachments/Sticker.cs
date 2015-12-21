using VkNet.Utils;

namespace VkNet.Model.Attachments
{
	/// <summary>
	/// Стикер.
	/// </summary>
	public class Sticker : MediaAttachment
    {
		/// <summary>
		/// Стикер.
		/// </summary>
		static Sticker()
        {
            RegisterType(typeof(Sticker), "sticker");
        }

		/// <summary>
		/// Идентификатор набора.
		/// </summary>
		public long? ProductId { get; set; }

		/// <summary>
		/// url изображения с высотой 64px.
		/// </summary>
		public string Photo64 { get; set; }

		/// <summary>
		/// url изображения с высотой 128px.
		/// </summary>
		public string Photo128 { get; set; }

		/// <summary>
		/// url изображения с высотой 256px.
		/// </summary>
		public string Photo256 { get; set; }

		/// <summary>
		/// url изображения с высотой 352px.
		/// </summary>
		public string Photo352 { get; set; }
		
		/// <summary>
		/// Ширина в px
		/// </summary>
		public long? Width { get; set; }

		/// <summary>
		/// Высота в px.
		/// </summary>
		public long? Height { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		internal static Sticker FromJson(VkResponse response)
		{
			var sticker = new Sticker
			{
				Id = response["id"],
				ProductId = response["product_id"],
				Photo64 = response["photo_64"],
				Photo128 = response["photo_128"],
				Photo256 = response["photo_256"],
				Photo352 = response["photo_352"],
				Width = response["width"],
				Height = response["height"]
			};

			return sticker;
		}
	}
}