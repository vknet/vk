using System.Runtime.Serialization;

namespace VkNet.Model
{
	using System;
	using Utils;

	/// <summary>
	/// Информация о лайках к записи.
	/// См. описание <see href="http://vk.com/dev/post"/>. Раздел likes.
	/// </summary>
	[DataContract]
	public class Likes
	{
		/// <summary>
		/// Число пользователей, которым понравилась запись.
		/// </summary>
		public int Count { get; set; }

		/// <summary>
		/// Признак понравилась ли запись текущему пользователю.
		/// </summary>
		public bool UserLikes { get; set; }

		/// <summary>
		/// Признак может ли текущий пользователь поставить отметку "Мне нравится".
		/// </summary>
		public bool CanLike { get; set; }

		/// <summary>
		/// Признак может ли текущий пользователь сделать репост записи (опубликовать у себя запись).
		/// </summary>
		public bool? CanPublish { get; set; }

		#region Методы
		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		public static Likes FromJson(VkResponse response)
		{
			var likes = new Likes
			{
				Count = response["count"],
				UserLikes = response["user_likes"],
				CanLike = response["can_like"],
				CanPublish = response["can_publish"]
			};

			return likes;
		}

		#endregion
	}
}