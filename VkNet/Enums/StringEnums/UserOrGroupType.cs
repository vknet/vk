using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Пользователь или сообщество.
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
public enum UserOrGroupType
{
	/// <summary>
	/// Пользователь.
	/// </summary>
	User,

	/// <summary>
	/// Сообщество.
	/// </summary>
	Group
}