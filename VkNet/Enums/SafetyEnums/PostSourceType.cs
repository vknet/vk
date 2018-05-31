using System;

namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// На данный момент поддерживаются следующие типы источников записи на стене,
	/// значение которых указываются в поле
	/// type:
	/// </summary>
	[Serializable]
	public class PostSourceType : SafetyEnum<PostSourceType>
	{
		/// <summary>
		/// Запись создана через основной интерфейс сайта (http://vk.com/).
		/// </summary>
		public static readonly PostSourceType Vk = RegisterPossibleValue(value: "vk");

		/// <summary>
		/// Запись создана через виджет на стороннем сайте.
		/// </summary>
		public static readonly PostSourceType Widget = RegisterPossibleValue(value: "widget");

		/// <summary>
		/// Запись создана приложением через API.
		/// </summary>
		public static readonly PostSourceType Api = RegisterPossibleValue(value: "api");

		/// <summary>
		/// Запись создана посредством импорта RSS-ленты со стороннего сайта.
		/// </summary>
		public static readonly PostSourceType Rss = RegisterPossibleValue(value: "rss");

		/// <summary>
		/// Запись создана посредством отправки SMS-сообщения на специальный номер.
		/// </summary>
		public static readonly PostSourceType Sms = RegisterPossibleValue(value: "sms");
	}
}