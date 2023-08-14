using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Пользователь или сообщество.
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
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