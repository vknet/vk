using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// тип документа
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
public enum DocMessageType
{
	/// <summary>
	/// DocMessageType
	/// </summary>
	Doc,

	/// <summary>
	/// голосовое сообщение
	/// </summary>
	AudioMessage,

	/// <summary>
	/// Граффити
	/// </summary>
	Graffiti
}