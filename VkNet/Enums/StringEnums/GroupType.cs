using Newtonsoft.Json;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Тип сообщества
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
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