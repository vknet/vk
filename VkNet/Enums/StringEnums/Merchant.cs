using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Магазин
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
public enum Merchant
{
	/// <summary>
	/// Google
	/// </summary>
	Google,

	/// <summary>
	/// Apple
	/// </summary>
	Apple,

	/// <summary>
	/// Microsoft
	/// </summary>
	Microsoft
}