using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Типы действий, которые должны произойти после нажатия на кнопку
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
public enum MessageEventType
{
	/// <summary>
	/// показать исчезающее сообщение.
	/// </summary>
	ShowSnackbar,

	/// <summary>
	/// открыть ссылку. Осуществляется переход по указанному адресу.
	/// </summary>
	OpenLink,

	/// <summary>
	/// открыть VK Mini App. Происходит переход в мини-приложение.
	/// </summary>
	OpenApp
}