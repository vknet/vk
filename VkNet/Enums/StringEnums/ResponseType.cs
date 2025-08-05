using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Тип ответа, который необходимо получить.
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
public enum ResponseType
{
	/// <summary>
	/// Токен.
	/// </summary>
	Token,

	/// <summary>
	/// Код.
	/// </summary>
	Code
}