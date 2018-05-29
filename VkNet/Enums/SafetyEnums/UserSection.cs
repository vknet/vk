namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Разделы среди которых нужно осуществить поиск, перечисленные через запятую:
	/// friends – искать среди друзей
	/// subscriptions – искать среди друзей и подписок пользователя список строк,
	/// разделенных через запятую.
	/// </summary>
	public sealed class UserSection : SafetyEnum<UserSection>
	{
		/// <summary>
		/// Искать среди друзей.
		/// </summary>
		public static readonly UserSection Friends = RegisterPossibleValue(value: "friends");

		/// <summary>
		/// Искать среди друзей и подписок пользователя список строк, разделенных через
		/// запятую.
		/// </summary>
		public static readonly UserSection Subscriptions = RegisterPossibleValue(value: "subscriptions");
	}
}