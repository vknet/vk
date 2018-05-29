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
		public static readonly AccountFields Country = RegisterPossibleValue(value: "country");

		/// <summary>
		/// Обязательно HTTPS.
		/// </summary>
		public static readonly AccountFields HttpsRequired = RegisterPossibleValue(value: "https_required");

		/// <summary>
		/// По умолчанию посты только владелец.
		/// </summary>
		public static readonly AccountFields OwnPostsDefault = RegisterPossibleValue(value: "own_posts_default");

		/// <summary>
		/// Не комментировать стену.
		/// </summary>
		public static readonly AccountFields NoWallReplies = RegisterPossibleValue(value: "no_wall_replies");

		/// <summary>
		/// Вступление.
		/// </summary>
		public static readonly AccountFields Intro = RegisterPossibleValue(value: "intro");

		/// <summary>
		/// Язык.
		/// </summary>
		public static readonly AccountFields Language = RegisterPossibleValue(value: "lang");
	}
}