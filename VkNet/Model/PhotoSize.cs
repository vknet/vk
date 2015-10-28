using System.Security.Policy;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Формат описания размеров фотографи.
	/// </summary>
	public class PhotoSize
	{
		/// <summary>
		/// Url копии изображения..
		/// </summary>
		public Url src
		{ get; set; }

		/// <summary>
		/// Ширина копии в пикселах..
		/// </summary>
		public ulong width
		{ get; set; }

		/// <summary>
		/// Высота копии в пикселах..
		/// </summary>
		public ulong height
		{ get; set; }

		/// <summary>
		/// Обозначение размера и пропорций копии..
		/// </summary>
		public PhotoSizeType type
		{ get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		internal static PhotoSize FromJson(VkResponse response)
		{
			var giftItem = new PhotoSize
			{
				src = new Url(response["src"]),
				width = response["width"],
				height = response["height"],
				type = response["type"]
			};

			return giftItem;
		}
	}
}
