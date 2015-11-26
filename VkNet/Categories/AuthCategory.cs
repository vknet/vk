using VkNet.Utils;

namespace VkNet.Categories
{
	/// <summary>
	/// Методы для работы с подарками.
	/// </summary>
	public class AuthCategory
	{
		/// <summary>
		/// API.
		/// </summary>
		private readonly VkApi _vk;

		/// <summary>
		/// Методы для работы с подарками.
		/// </summary>
		/// <param name="vk">API.</param>
		public AuthCategory(VkApi vk)
		{
			_vk = vk;
		}

		/// <summary>
		/// Проверяет правильность введённого номера.
		/// </summary>
		/// <returns>Возвращает результат выполнения метода.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/auth.checkPhone" />.
		/// </remarks>
		[ApiVersion("5.40")]
		public bool CheckPhone()
		{
			var parameters = new VkParameters
			{
			};
			return _vk.Call("auth.checkPhone", parameters);
		}

		/// <summary>
		/// Регистрирует нового пользователя по номеру телефона.
		/// </summary>
		/// <returns>Возвращает результат выполнения метода.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/auth.signup" />.
		/// </remarks>
		[ApiVersion("5.40")]
		public bool Signup()
		{
			var parameters = new VkParameters
			{
			};
			return _vk.Call("auth.signup", parameters);
		}

		/// <summary>
		/// Завершает регистрацию нового пользователя, начатую методом auth.signup, по коду, полученному через SMS.
		/// </summary>
		/// <returns>Возвращает результат выполнения метода.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/auth.confirm" />.
		/// </remarks>
		[ApiVersion("5.40")]
		public bool Confirm()
		{
			var parameters = new VkParameters
			{
			};
			return _vk.Call("auth.confirm", parameters);
		}

		/// <summary>
		/// Позволяет восстановить доступ к аккаунту, используя код, полученный через SMS.
		/// </summary>
		/// <param name="phone">Номер телефона пользователя.</param>
		/// <returns>
		/// Возвращает результат выполнения метода.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/auth.restore" />.
		/// </remarks>
		[ApiVersion("5.40")]
		public string Restore(string phone)
		{
			var response = _vk.Call("auth.restore", new VkParameters { { "phone", phone } });
			return response["sid"];
		}

	}
}