using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Типы предлагаемых друзей, которые нужно вернуть, перечисленные через запятую.
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
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