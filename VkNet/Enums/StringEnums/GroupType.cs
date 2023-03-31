using System.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using VkNet.Utils;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Тип сообщества
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
public enum GroupType
{
	/// <summary>
	/// Публичная страница.
	/// </summary>
	Page,

	/// <summary>
	/// Группа.
	/// </summary>
	Group,

	/// <summary>
	/// Мероприятие.
	/// </summary>
	Event,

	/// <summary>
	/// Не определено.
	/// </summary>
	[VkNetDefaultValue]
	Undefined
}