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
		public static readonly CommentObjectType Post = RegisterPossibleValue(value: "post");

		/// <summary>
		/// Фотография.
		/// </summary>
		public static readonly CommentObjectType Photo = RegisterPossibleValue(value: "photo");

		/// <summary>
		/// Видеозапись.
		/// </summary>
		public static readonly CommentObjectType Video = RegisterPossibleValue(value: "video");

		/// <summary>
		/// Обсуждение.
		/// </summary>
		public static readonly CommentObjectType Topic = RegisterPossibleValue(value: "topic");

		/// <summary>
		/// Заметка.
		/// </summary>
		public static readonly CommentObjectType Note = RegisterPossibleValue(value: "note");
	}
}