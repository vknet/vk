using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <summary>
	/// Методы для работы с авторизацией.
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
		/// <param name="phone">Номер телефона регистрируемого пользователя.</param>
		/// <param name="clientId">Идентификатор Вашего приложения.</param>
		/// <param name="clientSecret">Секретный ключ приложения, доступный в разделе редактирования приложения.</param>
		/// <returns>
		/// Возвращает результат выполнения метода.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/auth.checkPhone" />.
		/// </remarks>
		[ApiVersion("5.40")]
		public bool CheckPhone(string phone, long clientId, string clientSecret)
		{
			var parameters = new VkParameters
			{
				{ "phone", phone },
				{ "client_id", clientId },
				{ "client_secret", clientSecret }
			};
			return _vk.Call("auth.checkPhone", parameters);
		}

		/// <summary>
		/// Регистрирует нового пользователя по номеру телефона.
		/// </summary>
		/// <param name="params">Параметры запроса.</param>
		/// <returns>
		/// Возвращает результат выполнения метода.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/auth.signup" />.
		/// </remarks>
		[ApiVersion("5.40")]
		public string Signup(AuthSignupParams @params)
		{
			return _vk.Call("auth.signup", @params);
		}

		/// <summary>
		/// Завершает регистрацию нового пользователя, начатую методом auth.signup, по коду, полученному через SMS.
		/// </summary>
		/// <param name="params">Параметры запроса.</param>
		/// <returns>
		/// Возвращает результат выполнения метода.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/auth.confirm" />.
		/// </remarks>
		[ApiVersion("5.40")]
		public AuthConfirmResult Confirm(AuthConfirmParams @params)
		{
			return _vk.Call("auth.confirm", @params);
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