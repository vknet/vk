using VkNet.Utils;

namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Названия списков новостей, которые необходимо получить.
	/// </summary>
	public sealed class NewsTypes : SafetyEnum<NewsTypes>
	{
		/// <summary>
		/// Новые записи со стен.
		/// </summary>
		public static readonly NewsTypes Post = RegisterPossibleValue("post");


		/// <summary>
		/// Новые фотографии.
		/// </summary>
		public static readonly NewsTypes Photo = RegisterPossibleValue("photo");


		/// <summary>
		/// Новые отметки на фотографиях.
		/// </summary>
		public static readonly NewsTypes PhotoTag = RegisterPossibleValue("photo_tag");


		/// <summary>
		/// Новые фотографии на стенах.
		/// </summary>
		public static readonly NewsTypes WallPhoto = RegisterPossibleValue("wall_photo");


		/// <summary>
		/// Новые друзья.
		/// </summary>
		public static readonly NewsTypes Friend = RegisterPossibleValue("friend");


		/// <summary>
		/// Новые заметки.
		/// </summary>
		public static readonly NewsTypes Note = RegisterPossibleValue("note");

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		internal static NewsTypes FromJson(VkResponse response)
		{
			switch (response.ToString())
			{
				case "post":
					{
						return Post;
					}
				case "not_banned":
					{
						return Photo;
					}
				case "processing":
					{
						return PhotoTag;
					}
				case "WallPhoto":
					{
						return WallPhoto;
					}
				case "Friend":
					{
						return Friend;
					}
				case "Note":
					{
						return Note;
					}
			}

			return null;
		}
	}
}