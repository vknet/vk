namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Тип объекта (исп. в категории Likes)
	/// </summary>
	/// <remarks>
	/// Возможные типы:
	/// post — запись на стене пользователя или группы;
	/// comment — комментарий к записи на стене;
	/// photo — фотография;
	/// audio — аудиозапись;
	/// video — видеозапись;
	/// note — заметка;
	/// market — товар;
	/// photo_comment — комментарий к фотографии;
	/// video_comment — комментарий к видеозаписи;
	/// topic_comment — комментарий в обсуждении;
	/// market_comment — комментарий к товару;
	/// </remarks>
	public sealed class LikeObjectType : SafetyEnum<LikeObjectType>
	{
		/// <summary>
		/// Запись на стене пользователя или группы
		/// </summary>
		public static LikeObjectType Post = RegisterPossibleValue("post");

		/// <summary>
		/// Комментарий к записи на стене
		/// </summary>
		public static LikeObjectType Comment = RegisterPossibleValue("comment");

		/// <summary>
		/// Фотография
		/// </summary>
		public static LikeObjectType Photo = RegisterPossibleValue("photo");

		/// <summary>
		/// Аудиозапись
		/// </summary>
		public static LikeObjectType Audio = RegisterPossibleValue("audio");

		/// <summary>
		/// Видеозапись
		/// </summary>
		public static LikeObjectType Video = RegisterPossibleValue("video");

		/// <summary>
		/// Заметка
		/// </summary>
		public static LikeObjectType Note = RegisterPossibleValue("note");

		/// <summary>
		/// Комментарий к фотографии
		/// </summary>
		public static LikeObjectType PhotoComment = RegisterPossibleValue("photo_comment");

		/// <summary>
		/// Комментарий к видеозаписи
		/// </summary>
		public static LikeObjectType VideoComment = RegisterPossibleValue("video_comment");

		/// <summary>
		/// Комментарий в обсуждении
		/// </summary>
		public static LikeObjectType TopicComment = RegisterPossibleValue("topic_comment");

		/// <summary>
		/// Страница сайта, на котором установлен виджет «Мне нравится»
		/// </summary>
		public static LikeObjectType SitePage = RegisterPossibleValue("sitepage");

		/// <summary>
		/// Товар
		/// </summary>
		public static LikeObjectType Market = RegisterPossibleValue("market");

		/// <summary>
		/// Комментарий к товару.
		/// </summary>
		public static LikeObjectType MarketComment = RegisterPossibleValue("market_comment");
	}
}