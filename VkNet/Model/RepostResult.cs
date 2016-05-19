using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Результат копирования записи на стену и информация о ней.
	/// </summary>
	public class RepostResult
	{
		/// <summary>
		/// Результат копирования
		/// </summary>
		public bool Success { get; set; }

		/// <summary>
		/// Идентификатор созданной записи
		/// </summary>
		public long? PostId { get; set; }

		/// <summary>
		/// Число копирований исходной записи с учетом осуществленного
		/// </summary>
		public int? RepostsCount { get; set; }

		/// <summary>
		/// Число отметок "Мне нравится" у исходной записи
		/// </summary>
		public int? LikesCount { get; set; }

		#region Методы
		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		internal static RepostResult FromJson(VkResponse response)
		{
			var result = new RepostResult
			{
				Success = response["success"],
				PostId = response["post_id"],
				RepostsCount = response["reposts_count"],
				LikesCount = response["likes_count"]
			};

			return result;
		}

		#endregion

	}
}