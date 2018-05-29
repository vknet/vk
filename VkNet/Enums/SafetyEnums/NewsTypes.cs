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
		public static readonly NewsTypes Post = RegisterPossibleValue(value: "post");

		/// <summary>
		/// Новые фотографии.
		/// </summary>
		public static readonly NewsTypes Photo = RegisterPossibleValue(value: "photo");

		/// <summary>
		/// Новые отметки на фотографиях.
		/// </summary>
		public static readonly NewsTypes PhotoTag = RegisterPossibleValue(value: "photo_tag");

		/// <summary>
		/// Новые фотографии на стенах.
		/// </summary>
		public static readonly NewsTypes WallPhoto = RegisterPossibleValue(value: "wall_photo");

		/// <summary>
		/// Новые друзья.
		/// </summary>
		public static readonly NewsTypes Friend = RegisterPossibleValue(value: "friend");

		/// <summary>
		/// Новые заметки.
		/// </summary>
		public static readonly NewsTypes Note = RegisterPossibleValue(value: "note");
	}
}