using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using VkNet.Utils;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Тип кнопки сообщений.
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
public enum KeyboardButtonActionType
{
	/// <summary>
	/// Text
	/// </summary>
	[DefaultValue]
	Text,

	/// <summary>
	/// Location
	/// </summary>
	Location,

	/// <summary>
	/// VkPay
	/// </summary>
	Vkpay,

	/// <summary>
	/// Vk Apps
	/// </summary>
	OpenApp,

	/// <summary>
	/// Open Link
	/// </summary>
	OpenLink,

	/// <summary>
	/// Callback
	/// </summary>
	Callback,

	/// <summary>
	/// Отписаться
	/// </summary>
	IntentUnsubscribe,

	/// <summary>
	/// Подписаться
	/// </summary>
	IntentSubscribe
}