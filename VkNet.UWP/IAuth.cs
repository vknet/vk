namespace VkNet
{
    using System;

    /// <summary>
    /// Интерфейс синхронной авторизации в Vk
    /// </summary>
    public interface IAuth
    {
        /// <summary>
		/// Была ли произведена авторизация каким либо образом
		/// </summary>
        bool IsAuthorized { get; }

        /// <summary>
        /// Авторизация и получение токена
        /// </summary>
        /// <param name="params">Данные авторизации</param>
        void Authorize(AuthParams @params);

        /// <summary>
		/// Токен для доступа к методам API
		/// </summary>
        string Token { get; }

        /// <summary>
		/// Идентификатор пользователя, от имени которого была проведена авторизация.
		/// Если авторизация не была произведена с использованием метода Authorize(int
		/// то возвращается null.
		/// </summary>
        long? UserId { get; set; }

        /// <summary>
		/// Оповещает об истечении срока токена доступа
		/// </summary>
        event VkApiDelegate OnTokenExpires;

        /// <summary>
		/// Получает новый AccessToken используя логин, пароль, приложение и настройки указанные при последней авторизации.
		/// </summary>
		/// <param name="code">Делегат двух факторной авторизации. Если не указан - будет взят из параметров (если есть)</param>
		/// <exception cref="AggregateException">
		/// Невозможно обновить токен доступа т.к. последняя авторизация происходила не при помощи логина и пароля
		/// </exception>
        void RefreshToken(Func<string> code = null);
    }
}