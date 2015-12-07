using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Является опциональным и содержит следующие данные в зависимости от значения поля type:
	/// </summary>
	public class PostSourceData
	{
		/// <summary>
		/// Изменение статуса под именем пользователя.
		/// </summary>
		public string ProfileActivity;

		/// <summary>
		/// Изменение профильной фотографии пользователя.
		/// </summary>
		public string ProfilePhoto;

		/// <summary>
		/// Виджет комментариев.
		/// </summary>
		public string Comments;

		/// <summary>
		/// Виджет «Мне нравится».
		/// </summary>
		public string Like;

		/// <summary>
		/// Виджет опросов.
		/// </summary>
		public string Poll;

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		internal static PostSourceData FromJson(VkResponse response)
		{
			var postSource = new PostSourceData
			{
				ProfileActivity = response["profile_activity"],
				ProfilePhoto = response["profile_photo"],
				Comments = response["comments"],
				Like = response["like"],
				Poll = response["poll"]
			};

			return postSource;
		}
	}
}