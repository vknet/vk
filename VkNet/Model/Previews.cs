using VkNet.Model.Attachments;

namespace VkNet.Model
{
	using System;
	using Utils;

	/// <summary>
	/// Набор Url к картинкам с различным разрешениям.
	/// Используется в <see cref="User"/>, <see cref="Group"/> и <see cref="Message"/>.
	/// </summary>
	[Serializable]
	public class Previews
	{
		/// <summary>
		/// Url квадратной фотографии, имеющей ширину 50 пикселей.
		/// </summary>
		public Uri Photo50 { get; set; }

		/// <summary>
		/// Url квадратной фотографии, имеющей ширину 100 пикселей.
		/// </summary>
		public Uri Photo100 { get; set; }

		/// <summary>
		/// Url квадратной фотографии, имеющей ширину 130 пикселей.
		/// </summary>
		public Uri Photo130 { get; set; }

		/// <summary>
		/// Url квадратной фотографии, имеющей ширину 200 пикселей.
		/// </summary>
		public Uri Photo200 { get; set; }

		/// <summary>
		/// Url квадратной фотографии, имеющей ширину 400 пикселей.
		/// </summary>
		public Uri Photo400 { get; set; }

		/// <summary>
		/// Url квадратной фотографии, имеющей максимальную ширину.
		/// </summary>
		public Uri PhotoMax { get; set; }

        /// <summary>
        /// Gets or sets the photo.
        /// </summary>
        public Photo Photo { get; set; }
	    
		#region Методы
		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		internal static Previews FromJson(VkResponse response)
		{
			var previews = new Previews
			{
				Photo50 = response["photo_50"],
				Photo100 = response["photo_100"] ?? response["photo_medium"],
				Photo130 = response["photo_130"],
				Photo200 = response["photo_200"] ?? response["photo_200_orig"],
				Photo400 = response["photo_400_orig"],
                Photo = response["photo"]
            };

			previews.PhotoMax = response["photo_max"] ?? response["photo_max_orig"] ?? response["photo_big"] ?? previews.Photo400 ?? previews.Photo200 ?? previews.Photo100 ?? previews.Photo50;

			return previews;
		}

		#endregion
	}
}