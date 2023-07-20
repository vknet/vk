using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Тип объекта поиска
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
public enum SearchResultType
{
	/// <summary>
	/// Сообщество
	/// </summary>
	Group,

	/// <summary>
	/// Профиль
	/// </summary>
	Profile
}