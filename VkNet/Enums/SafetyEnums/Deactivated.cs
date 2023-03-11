using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using VkNet.Utils;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Возможные значения параметра Deactivated.
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
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
	[DefaultValue]
	Activated
}