using System;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Рейтинг.
	/// </summary>
	[Serializable]
	public class Rating
	{
		/// <summary>
		/// Количество звезд у продукта;.
		/// </summary>
		public long? Stars { get; set; }

		/// <summary>
		/// Количество отзывов о продукте;.
		/// </summary>
		public long? ReviewsCount { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static Rating FromJson(VkResponse response)
		{
			var rating = new Rating
			{
					Stars = response[key: "stars"]
					, ReviewsCount = response[key: "reviews_count"]
			};

			return rating;
		}
	}
}