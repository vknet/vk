using System;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Копия изображения обложки.
	/// </summary>
	[Serializable]
	public class GroupCoverImage
	{
		/// <summary>
		/// URL копии;
		/// </summary>
		public Uri Url { get; set; }

		/// <summary>
		/// Ширина копии;
		/// </summary>
		public int Width { get; set; }

		/// <summary>
		/// Высота копии.
		/// </summary>
		public int Height { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static GroupCoverImage FromJson(VkResponse response)
		{
			return new GroupCoverImage
			{
					Url = response[key: "url"]
					, Width = response[key: "width"]
					, Height = response[key: "height"]
			};
		}
	}
}