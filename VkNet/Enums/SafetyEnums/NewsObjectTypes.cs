namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Названия списков новостей, которые необходимо получить.
	/// </summary>
	public sealed class NewsObjectTypes : SafetyEnum<NewsObjectTypes>
	{
		/// <summary>
		/// Запись на стене.
		/// </summary>
		public static readonly NewsObjectTypes Wall = RegisterPossibleValue(value: "wall");

		/// <summary>
		/// Отметка на фотографии.
		/// </summary>
		public static readonly NewsObjectTypes Tag = RegisterPossibleValue(value: "tag");

		/// <summary>
		/// Фотография профиля.
		/// </summary>
		public static readonly NewsObjectTypes ProfilePhoto = RegisterPossibleValue(value: "profilephoto");

		/// <summary>
		/// Видеозапись.
		/// </summary>
		public static readonly NewsObjectTypes Video = RegisterPossibleValue(value: "video");

		/// <summary>
		/// Фотография.
		/// </summary>
		public static readonly NewsObjectTypes Photo = RegisterPossibleValue(value: "photo");

		/// <summary>
		/// Аудиозапись.
		/// </summary>
		public static readonly NewsObjectTypes Audio = RegisterPossibleValue(value: "audio");
	}
}