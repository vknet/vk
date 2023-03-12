using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.SafetyEnums;

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
	SnowSnackbar,

	/// <summary>
	/// открыть ссылку. Осуществляется переход по указанному адресу.
	/// </summary>
	OpenLink,

	/// <summary>
	/// открыть VK Mini App. Происходит переход в мини-приложение.
	/// </summary>
	OpenApp
}