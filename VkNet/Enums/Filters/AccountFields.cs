namespace VkNet.Enums.Filters
{
	/// <summary>
	/// Поля информации о аккаунте.
	/// </summary>
	public sealed class AccountFields : MultivaluedFilter<AccountFields>
	{
		/// <summary>
		/// Страна.
		/// </summary>
		public static readonly AccountFields Country = RegisterPossibleValue("country");

		/// <summary>
		/// Обязательно HTTPS.
		/// </summary>
		public static readonly AccountFields HttpsRequired = RegisterPossibleValue("https_required");

		/// <summary>
		/// По умолчанию посты только владелец.
		/// </summary>
		public static readonly AccountFields OwnPostsDefault = RegisterPossibleValue("own_posts_default");

		/// <summary>
		/// Не комментировать стену.
		/// </summary>
		public static readonly AccountFields NoWallReplies = RegisterPossibleValue("no_wall_replies");

		/// <summary>
		/// Вступление.
		/// </summary>
		public static readonly AccountFields Intro = RegisterPossibleValue("intro");

		/// <summary>
		/// Язык.
		/// </summary>
		public static readonly AccountFields Language = RegisterPossibleValue("lang");
	}
}