namespace VkNet.Enums.Filters
{
	/// <summary>
	/// Названия списков новостей, которые необходимо получить.
	/// </summary>
	public sealed class NewsTypes : MultivaluedFilter<NewsTypes>
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
		/// Новые аудиозаписи.
		/// </summary>
		public static readonly NewsTypes Audio = RegisterPossibleValue("audio");

		/// <summary>
		/// Новые видеозаписи.
		/// </summary>
		public static readonly NewsTypes Video = RegisterPossibleValue("video");
	}
}