using System.Runtime.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Типы предлагаемых друзей, которые нужно вернуть, перечисленные через запятую.
/// </summary>
public sealed class FriendsFilter : SafetyEnum<FriendsFilter>
{
	/// <summary>
	/// Пользователи, с которыми много общих друзей;
	/// </summary>
	[EnumMember(Value = "mutual")]
	public static readonly FriendsFilter Mutual = RegisterPossibleValue(value: "mutual");

	/// <summary>
	/// Пользователи, найденные с помощью метода account.importContacts;
	/// </summary>
	[EnumMember(Value = "contacts")]
	public static readonly FriendsFilter Contacts = RegisterPossibleValue(value: "contacts");

	/// <summary>
	/// Пользователи, которые импортировали те же контакты, что и текущий пользователь,
	/// используя метод
	/// account.importContacts;
	/// </summary>
	[EnumMember(Value = "mutual_contacts")]
	public static readonly FriendsFilter MutualContacts = RegisterPossibleValue(value: "mutual_contacts");
}