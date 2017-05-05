﻿namespace VkNet.Categories
{
    using Model;
    using Model.RequestParams;

    /// <summary>
	/// Методы для работы с авторизацией.
	/// </summary>
    public interface IAuthCategory
    {
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
        bool CheckPhone(string phone, string clientSecret, long? clientId = null, bool? authByPhone = null);

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
        string Signup(AuthSignupParams @params);

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
        AuthConfirmResult Confirm(AuthConfirmParams @params);

        /// <summary>
        /// Позволяет восстановить доступ к аккаунту, используя код, полученный через SMS.
        /// </summary>
        /// <param name="phone">Номер телефона пользователя.</param>
        /// <returns>
        /// Возвращает результат выполнения метода.
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте https://vk.com/dev/auth.restore
        /// </remarks>
        string Restore(string phone);
    }
}