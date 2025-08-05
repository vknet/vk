using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Типы предлагаемых друзей, которые нужно вернуть, перечисленные через запятую.
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
public enum FriendsFilter
{
	/// <summary>
	/// Пользователи, с которыми много общих друзей;
	/// </summary>
	Mutual,

	/// <summary>
	/// Пользователи, найденные с помощью метода account.importContacts;
	/// </summary>
	Contacts,

	/// <summary>
	/// Пользователи, которые импортировали те же контакты, что и текущий пользователь,
	/// используя метод
	/// account.importContacts;
	/// </summary>
	MutualContacts
}