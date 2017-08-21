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
        /// <param name="phone">Номер телефона регистрируемого пользователя. строка, обязательный параметр (Строка, обязательный параметр).</param>
        /// <param name="clientId">Идентификатор Вашего приложения. целое число (Целое число).</param>
        /// <param name="clientSecret">Секретный ключ приложения, доступный в разделе редактирования приложения. строка, обязательный параметр (Строка, обязательный параметр).</param>
        /// <param name="authByPhone">Флаг, может принимать значения 1 или 0 (Флаг, может принимать значения 1 или 0).</param>
        /// <returns>
        /// В случае, если номер пользователя является правильным, будет возвращён <c>true</c>.
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте http://vk.com/dev/auth.checkPhone
        /// </remarks>
        public bool CheckPhone(string phone, string clientSecret, long? clientId = null, bool? authByPhone = null)
        {
            var parameters = new VkParameters
            {
                {"phone", phone},
                {"client_id", clientId},
                {"client_secret", clientSecret},
                {"auth_by_phone", authByPhone}
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
        /// Страница документации ВКонтакте https://vk.com/dev/auth.signup
        /// </remarks>
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
        /// Страница документации ВКонтакте https://vk.com/dev/auth.confirm
        /// </remarks>
        public AuthConfirmResult Confirm(AuthConfirmParams @params)
        {
            return _vk.Call("auth.confirm", @params);
        }

        /// <summary>
        /// Позволяет восстановить доступ к аккаунту, используя код, полученный через SMS.
        /// </summary>
        /// <param name="phone">Номер телефона пользователя.</param>
        /// <param name="lastName">Фамилия пользователя.</param>
        /// <returns>
        /// Возвращает результат выполнения метода.
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте https://vk.com/dev/auth.restore
        /// </remarks>
        public string Restore(string phone, string lastName)
        {
            var response = _vk.Call("auth.restore", new VkParameters {{"phone", phone}, {"last_name", lastName}});
            return response["sid"];
        }
    }
}