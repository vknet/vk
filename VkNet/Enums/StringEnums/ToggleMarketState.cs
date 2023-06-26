using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Значение переключателя.
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
public enum ToggleMarketState
{
	/// <summary>
	/// Товары отключены
	/// </summary>
	None,

	/// <summary>
	/// Базовые товары
	/// </summary>
	Basic ,

	/// <summary>
	/// Расширенные товары
	/// </summary>
	Advanced
}