using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Права пользователя в рекламном кабинете.
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
public enum IdsType
{
	/// <summary>
	/// Объявление.
	/// </summary>
	Ad,

	/// <summary>
	/// Кампания.
	/// </summary>
	Campaign
}