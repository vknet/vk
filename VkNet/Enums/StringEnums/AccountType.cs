using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Тип рекламного кабинета.
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
public enum AccountType
{
	/// <summary>
	/// Обычный
	/// </summary>
	General,

	/// <summary>
	/// Обычный
	/// </summary>
	Agency
}