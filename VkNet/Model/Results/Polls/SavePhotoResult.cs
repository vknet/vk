using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Результат метода SavePhoto
	/// </summary>
	[Serializable]
	public class SavePhotoResult
	{
		/// <summary>
		///
		/// </summary>
		[JsonProperty("color")]
		public string Color { get; set; }

		/// <summary>
		/// Идентификатор загруженной фотографии
		/// </summary>
		[JsonProperty("id")]
		public long Id { get; set; }

		/// <summary>
		/// Массив изображений разных размеров
		/// </summary>
		[JsonProperty("images")]
		public Image[] Images { get; set; }

		public static SavePhotoResult FromJson(VkResponse response)
		{
			return new SavePhotoResult
			{
				Color = response["color"],
				Id = response["id"],
				Images = response["images"].ToListOf<Image>(x => x).ToArray()
			};
		}
	}
}