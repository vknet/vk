using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Действие с тегом
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
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