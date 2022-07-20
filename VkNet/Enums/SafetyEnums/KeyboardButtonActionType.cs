using VkNet.Utils;

namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Тип кнопки сообщений.
	/// </summary>
	public class KeyboardButtonActionType : SafetyEnum<KeyboardButtonActionType>
	{
		/// <summary>
		/// Text
		/// </summary>
		[DefaultValue]
		public static readonly KeyboardButtonActionType Text = RegisterPossibleValue("text");

		/// <summary>
		/// Location
		/// </summary>
		public static readonly KeyboardButtonActionType Location = RegisterPossibleValue("location");

		/// <summary>
		/// VkPay
		/// </summary>
		public static readonly KeyboardButtonActionType VkPay = RegisterPossibleValue("vkpay");

		/// <summary>
		/// Vk Apps
		/// </summary>
		public static readonly KeyboardButtonActionType VkApp = RegisterPossibleValue("open_app");

		/// <summary>
		/// Open Link
		/// </summary>
		public static readonly KeyboardButtonActionType OpenLink = RegisterPossibleValue("open_link");

		/// <summary>
		/// Callback
		/// </summary>
		public static readonly KeyboardButtonActionType Callback = RegisterPossibleValue("callback");

		/// <summary>
		/// Отписаться
		/// </summary>
		public static readonly KeyboardButtonActionType IntentUnsubscribe = RegisterPossibleValue("intent_unsubscribe");

		/// <summary>
		/// Подписаться
		/// </summary>
		public static readonly KeyboardButtonActionType IntentSubscribe = RegisterPossibleValue("intent_subscribe");
	}
}