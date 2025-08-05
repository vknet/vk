using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Типы действий, которые должны произойти после нажатия на кнопку
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
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