using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Действие с тегом
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
public enum GroupTagAct
{
	/// <summary>
	/// Привязать
	/// </summary>
	Bind,

	/// <summary>
	/// Отвязать
	/// </summary>
	Unbind
}