using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Информация о телефонных номерах пользователя.
	/// </summary>
	public class Contacts
	{
		/// <summary>
		/// Номер мобильного телефона пользователя (только для Standalone-приложений).
		/// </summary>
		public string MobilePhone { get; set; }

		/// <summary>
		/// Дополнительный номер телефона пользователя.
		/// </summary>
		public string HomePhone { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		internal static Contacts FromJson(VkResponse response)
		{
			var contacts = new Contacts
			{
				MobilePhone = response["mobile_phone"],
				HomePhone = response["home_phone"]
			};

			return contacts;
		}
	}
}