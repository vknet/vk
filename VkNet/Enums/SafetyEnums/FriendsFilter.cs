namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Типы предлагаемых друзей, которые нужно вернуть, перечисленные через запятую.
	/// </summary>
	public sealed class FriendsFilter : SafetyEnum<FriendsFilter>
	{
		/// <summary>
		/// Пользователи, с которыми много общих друзей;
		/// </summary>
		public static readonly FriendsFilter Mutual = RegisterPossibleValue(value: "mutual");

		/// <summary>
		/// Пользователи, найденные с помощью метода account.importContacts;
		/// </summary>
		public static readonly FriendsFilter Contacts = RegisterPossibleValue(value: "contacts");

		/// <summary>
		/// Пользователи, которые импортировали те же контакты, что и текущий пользователь,
		/// используя метод
		/// account.importContacts;
		/// </summary>
		public static readonly FriendsFilter MutualContacts = RegisterPossibleValue(value: "mutual_contacts");
	}
}