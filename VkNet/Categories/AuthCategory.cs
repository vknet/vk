using VkNet.Model;
using VkNet.Model.Auth;
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
		/// <returns>Возвращает результат выполнения метода.</returns>
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
		/// <returns>Возвращает результат выполнения метода.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/auth.signup" />.
		/// </remarks>
		[ApiVersion("5.40")]
		public string Signup(AuthSignupParams @params)
		{
			var parameters = new VkParameters
			{
				{ "first_name", @params.first_name },
				{ "last_name", @params.last_name },
				{ "client_id", @params.client_id },
				{ "client_secret", @params.client_secret },
				{ "phone", @params.phone },
				{ "password", @params.password },
				{ "test_mode", @params.test_mode },
				{ "voice", @params.voice },
				{ "sex", @params.sex },
				{ "sid", @params.sid }
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
		public AuthConfirmResult Confirm(AuthConfirmParams @params)
		{
			var parameters = new VkParameters
			{
				{ "client_id", @params.ClientId },
				{ "client_secret", @params.ClientSecret },
				{ "phone", @params.Phone },
				{ "code", @params.Code },
				{ "password", @params.Password },
				{ "test_mode", @params.TestMode },
				{ "intro", @params.Intro }
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