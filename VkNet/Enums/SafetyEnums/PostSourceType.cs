using VkNet.Enums.SafetyEnums;
using VkNet.Utils;

namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// На данный момент поддерживаются следующие типы источников записи на стене, значение которых указываются в поле type:
	/// </summary>
	public class PostSourceType : SafetyEnum<PostSourceType>
	{
		/// <summary>
		/// запись создана через основной интерфейс сайта (http://vk.com/);.
		/// </summary>
		public static readonly PostSourceType Vk = RegisterPossibleValue("vk");

		/// <summary>
		/// запись создана через виджет на стороннем сайте;.
		/// </summary>
		public static readonly PostSourceType Widget = RegisterPossibleValue("widget");

		/// <summary>
		/// запись создана приложением через API;.
		/// </summary>
		public static readonly PostSourceType Api = RegisterPossibleValue("api");

		/// <summary>
		/// запись создана посредством импорта RSS-ленты со стороннего сайта;.
		/// </summary>
		public static readonly PostSourceType Rss = RegisterPossibleValue("rss");

		/// <summary>
		/// запись создана посредством отправки SMS-сообщения на специальный номер..
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
			}

			return null;
		}
	}
}