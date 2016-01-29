using System;
using VkNet.Utils;

namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// На данный момент поддерживаются следующие типы источников записи на стене, значение которых указываются в поле type:
	/// </summary>
	[Serializable]
	public class PostSourceType : SafetyEnum<PostSourceType>
	{
		/// <summary>
		/// Запись создана через основной интерфейс сайта (http://vk.com/).
		/// </summary>
		public static readonly PostSourceType Vk = RegisterPossibleValue("vk");

		/// <summary>
		/// Запись создана через виджет на стороннем сайте.
		/// </summary>
		public static readonly PostSourceType Widget = RegisterPossibleValue("widget");

		/// <summary>
		/// Запись создана приложением через API.
		/// </summary>
		public static readonly PostSourceType Api = RegisterPossibleValue("api");

		/// <summary>
		/// Запись создана посредством импорта RSS-ленты со стороннего сайта.
		/// </summary>
		public static readonly PostSourceType Rss = RegisterPossibleValue("rss");

		/// <summary>
		/// Запись создана посредством отправки SMS-сообщения на специальный номер.
		/// </summary>
		public static readonly PostSourceType Sms = RegisterPossibleValue("sms");


		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		internal static PostSourceType FromJson(VkResponse response)
		{
			switch (response.ToString())
			{
				case "vk":
					{
						return Vk;
					}
				case "widget":
					{
						return Widget;
					}
				case "api":
					{
						return Api;
					}
				case "rss":
					{
						return Rss;
					}
				case "sms":
					{
						return Sms;
					}
				default:
					{
						return null;
					}
			}
		}
	}
}