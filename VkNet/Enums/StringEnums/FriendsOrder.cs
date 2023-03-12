using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Порядок, в котором необходимо вернуть список друзей.
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
public enum FriendsOrder
{
	/// <summary>
	/// Сортировать по имени (работает только при переданном параметре fields).
	/// </summary>
	Name,

	/// <summary>
	/// Сортировать по рейтингу, аналогично тому, как друзья сортируются в разделе "Мои
	/// друзья".
	/// </summary>
	Hints,

	/// <summary>
	/// Возвращает друзей в случайном порядке.
	/// </summary>
	Random
}