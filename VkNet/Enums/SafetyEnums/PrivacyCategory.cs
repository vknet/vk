using System.Text.RegularExpressions;
using VkNet.Utils;

namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Категории уровней доступа
	/// </summary>
	public sealed class PrivacyCategory : SafetyEnum<PrivacyCategory>
	{
		/// <summary>
		/// Доступно всем пользователям.
		/// </summary>
		[DefaultValue]
		public static readonly PrivacyCategory All = RegisterPossibleValue(value: "all");

		/// <summary>
		/// Доступно друзьям текущего пользователя.
		/// </summary>
		public static readonly PrivacyCategory Friends = RegisterPossibleValue(value: "friends");

		/// <summary>
		/// Доступно друзьям и друзьям друзей.
		/// </summary>
		public static readonly PrivacyCategory FriendsOfFriends = RegisterPossibleValue(value: "friends_of_friends");

		/// <summary>
		/// Доступно друзьям друзей текущего пользователя.
		/// </summary>
		public static readonly PrivacyCategory FriendsOfFriendsOnly = RegisterPossibleValue(value: "friends_of_friends_only");

		/// <summary>
		/// Доступно только мне.
		/// </summary>
		public static readonly PrivacyCategory OnlyMe = RegisterPossibleValue(value: "only_me");
	}
}