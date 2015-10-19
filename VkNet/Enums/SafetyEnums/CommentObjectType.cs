namespace VkNet.Enums.SafetyEnums
{
    /// <summary>
    /// Тип комментариев.
    /// </summary>
	public sealed class CommentObjectType : SafetyEnum<CommentObjectType>
    {
		/// <summary>
		/// запись на стене пользователя или группы;.
		/// </summary>
		public static readonly CommentObjectType Post = RegisterPossibleValue("post");


		/// <summary>
		/// фотография;.
		/// </summary>
		public static readonly CommentObjectType Photo = RegisterPossibleValue("photo");


		/// <summary>
		/// видеозапись;.
		/// </summary>
		public static readonly CommentObjectType Video = RegisterPossibleValue("video");


		/// <summary>
		/// обсуждение;.
		/// </summary>
		public static readonly CommentObjectType Topic = RegisterPossibleValue("topic");


		/// <summary>
		/// заметка..
		/// </summary>
		public static readonly CommentObjectType Note = RegisterPossibleValue("note");


	}
}