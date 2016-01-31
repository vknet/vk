﻿using VkNet.Model;
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
		/// <param name="phone">Номер телефона регистрируемого пользователя. строка, обязательный параметр (Строка, обязательный параметр).</param>
		/// <param name="clientId">Идентификатор Вашего приложения. целое число (Целое число).</param>
		/// <param name="clientSecret">Секретный ключ приложения, доступный в разделе редактирования приложения. строка, обязательный параметр (Строка, обязательный параметр).</param>
		/// <param name="authByPhone">Флаг, может принимать значения 1 или 0 (Флаг, может принимать значения 1 или 0).</param>
		/// <returns>
		/// В случае, если номер пользователя является правильным, будет возвращён <c>true</c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/auth.checkPhone" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public bool CheckPhone(string phone, string clientSecret, long? clientId = null, bool? authByPhone = null)
		{
			var parameters = new VkParameters {
				{ "phone", phone },
				{ "client_id", clientId },
				{ "client_secret", clientSecret },
				{ "auth_by_phone", authByPhone }
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
		[ApiVersion("5.44")]
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
		[ApiVersion("5.44")]
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
		[ApiVersion("5.44")]
		public string Restore(string phone)
		{
			var response = _vk.Call("auth.restore", new VkParameters { { "phone", phone } });
			return response["sid"];
		}

	}
}