using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Хранит информацию о текущем аккаунте. Подробнее: <see cref="https://vk.com/dev/account.getInfo"/>
	/// </summary>
	public class AccountInfo
	{
		/// <summary>
		/// Строковой код страны, определенный по IP адресу, с которого сделан запрос.
		/// </summary>
		public string Country { get; set; }

		/// <summary>
		/// Пользователь установил в настройках аккаунта "Всегда использовать безопасное соединение"
		/// </summary>
		public bool? HttpsRequired { get; set; }

		/// <summary>
		/// Битовая маска, отвечающая за прохождение обучения использованию приложения.
		/// </summary>
		public int? Intro { get; set; }

		/// <summary>
		/// Числовой идентификатор текущего языка пользователя.
		/// </summary>
		public int? Language { get; set; }

		
		#region Методы

		internal static AccountInfo FromJson(VkResponse response)
		{
			AccountInfo info = new AccountInfo();

			info.Country = response["country"];
			info.HttpsRequired = response["https_required"];
			info.Intro = response["intro"];
			info.Language = response["lang"];

			return info;
		}

		#endregion 
	}
}