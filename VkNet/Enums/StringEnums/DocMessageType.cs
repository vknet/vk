using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// тип документа
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
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