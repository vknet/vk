using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Источник контента.
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
public enum MessageContentSourceType
{
	/// <summary>
	/// Сообщение
	/// </summary>
	Message,

	/// <summary>
	/// Ссылка
	/// </summary>
	Url
}