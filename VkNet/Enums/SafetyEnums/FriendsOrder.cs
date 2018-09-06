namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Порядок, в котором необходимо вернуть список друзей.
	/// </summary>
	public sealed class FriendsOrder : SafetyEnum<FriendsOrder>
	{
		/// <summary>
		/// Сортировать по имени (работает только при переданном параметре fields).
		/// </summary>
		public static readonly FriendsOrder Name = RegisterPossibleValue(value: "name");

		/// <summary>
		/// Сортировать по рейтингу, аналогично тому, как друзья сортируются в разделе "Мои
		/// друзья".
		/// </summary>
		public static readonly FriendsOrder Hints = RegisterPossibleValue(value: "hints");

		/// <summary>
		/// Возвращает друзей в случайном порядке.
		/// </summary>
		public static readonly FriendsOrder Random = RegisterPossibleValue(value: "random");
	}
}