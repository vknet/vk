namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Тип комментариев.
	/// </summary>
	public sealed class CommentObjectType : SafetyEnum<CommentObjectType>
	{
		/// <summary>
		/// Запись на стене пользователя или группы.
		/// </summary>
		public static readonly CommentObjectType Post = RegisterPossibleValue("post");


		/// <summary>
		/// Фотография.
		/// </summary>
		public static readonly CommentObjectType Photo = RegisterPossibleValue("photo");


		/// <summary>
		/// Видеозапись.
		/// </summary>
		public static readonly CommentObjectType Video = RegisterPossibleValue("video");


		/// <summary>
		/// Обсуждение.
		/// </summary>
		public static readonly CommentObjectType Topic = RegisterPossibleValue("topic");


		/// <summary>
		/// Заметка.
		/// </summary>
		public static readonly CommentObjectType Note = RegisterPossibleValue("note");
	}
}