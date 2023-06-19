using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using VkNet.Utils;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Цвет кнопки клавиатуры отправляемой ботом.
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
public enum KeyboardButtonColor
{
	/// <summary>
	/// обычная белая кнопка. #FFFFFF
	/// </summary>
	[VkNetDefaultValue]
	Default,

	/// <summary>
	/// синяя кнопка, обозначает основное действие. #5181B8
	/// </summary>
	Primary,

	/// <summary>
	/// опасное действие, или отрицательное действие (отклонить, удалить и тд). #E64646
	/// </summary>
	Negative,

	/// <summary>
	/// согласиться, подтвердить. #4BB34B
	/// </summary>
	Positive
}