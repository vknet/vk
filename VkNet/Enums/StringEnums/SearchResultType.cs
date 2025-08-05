using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Тип объекта поиска
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
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