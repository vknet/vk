using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Рейтинг.
	/// </summary>
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
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		internal static Rating FromJson(VkResponse response)
		{
			var rating = new Rating
			{
				Stars = response["stars"],
				ReviewsCount = response["reviews_count"]
			};

			return rating;
		}
	}
}