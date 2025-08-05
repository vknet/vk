using Newtonsoft.Json;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Тип кнопки сообщений.
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
public enum KeyboardButtonActionType
{
	/// <summary>
	/// Text
	/// </summary>
	[VkNetDefaultValue]
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
	/// Open Link
	/// </summary>
	OpenPhoto,

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
	IntentSubscribe,

 	/// <summary>
	/// Открыть модальный вид
	/// </summary>
	OpenModalView,
}
