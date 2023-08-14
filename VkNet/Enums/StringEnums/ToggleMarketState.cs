using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Значение переключателя.
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
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