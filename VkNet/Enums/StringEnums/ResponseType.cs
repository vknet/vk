using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Тип ответа, который необходимо получить.
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
public enum ResponseType
{
	/// <summary>
	/// Токен.
	/// </summary>
	Token,

	/// <summary>
	/// Код.
	/// </summary>
	Сode
}