using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Тип рекламного кабинета.
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
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