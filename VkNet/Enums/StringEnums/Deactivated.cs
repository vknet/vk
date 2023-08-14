using Newtonsoft.Json;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Возможные значения параметра Deactivated.
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
public enum Deactivated
{
	/// <summary>
	/// Удалено.
	/// </summary>
	Deleted,

	/// <summary>
	/// Заблокировано.
	/// </summary>
	Banned,

	/// <summary>
	/// Активно.
	/// </summary>
	[VkNetDefaultValue]
	Activated
}