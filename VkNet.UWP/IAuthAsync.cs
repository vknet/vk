namespace VkNet
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Интерфейс асинхронной авторизации в Vk
    /// </summary>
    public interface IAuthAsync : IAuth
    {
        /// <summary>
        /// Авторизация и получение токена в асинхронном режиме
        /// </summary>
        /// <param name="params">Данные авторизации</param>
        Task AuthorizeAsync(AuthParams @params);

        /// <summary>
		/// Получает новый AccessToken использую логин, пароль, приложение и настройки указанные при последней авторизации.
		/// </summary>
		/// <param name="code">Делегат двух факторной авторизации. Если не указан - будет взят из параметров (если есть)</param>
        Task RefreshTokenAsync(Func<string> code = null);
    }
}