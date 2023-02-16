using System.Runtime.Serialization;
using VkNet.Utils;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Тип кнопки сообщений.
/// </summary>
public class KeyboardButtonActionType : SafetyEnum<KeyboardButtonActionType>
{
	/// <summary>
	/// Text
	/// </summary>
	[DefaultValue]
	[EnumMember(Value = "text")]
	public static readonly KeyboardButtonActionType Text = RegisterPossibleValue("text");

	/// <summary>
	/// Location
	/// </summary>
	[EnumMember(Value = "location")]
	public static readonly KeyboardButtonActionType Location = RegisterPossibleValue("location");

	/// <summary>
	/// VkPay
	/// </summary>
	[EnumMember(Value = "vkpay")]
	public static readonly KeyboardButtonActionType VkPay = RegisterPossibleValue("vkpay");

	/// <summary>
	/// Vk Apps
	/// </summary>
	[EnumMember(Value = "open_app")]
	public static readonly KeyboardButtonActionType VkApp = RegisterPossibleValue("open_app");

	/// <summary>
	/// Open Link
	/// </summary>
	[EnumMember(Value = "open_link")]
	public static readonly KeyboardButtonActionType OpenLink = RegisterPossibleValue("open_link");

	/// <summary>
	/// Callback
	/// </summary>
	[EnumMember(Value = "callback")]
	public static readonly KeyboardButtonActionType Callback = RegisterPossibleValue("callback");

	/// <summary>
	/// Отписаться
	/// </summary>
	[EnumMember(Value = "intent_unsubscribe")]
	public static readonly KeyboardButtonActionType IntentUnsubscribe = RegisterPossibleValue("intent_unsubscribe");

	/// <summary>
	/// Подписаться
	/// </summary>
	[EnumMember(Value = "intent_subscribe")]
	public static readonly KeyboardButtonActionType IntentSubscribe = RegisterPossibleValue("intent_subscribe");
}