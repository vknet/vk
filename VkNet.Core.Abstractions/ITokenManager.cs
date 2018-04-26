namespace VkNet.Core.Abstractions
{
    /// <summary>
    /// Менеджер управления токеном
    /// </summary>
    public interface ITokenManager
    {
        /// <summary>
        /// Токен приложения
        /// </summary>
        string Token { get; }
        /// <summary>
        /// <c>true</c> - если истек
        /// </summary>
        bool IsExpired { get; }
        /// <summary>
        /// Обновить токен
        /// </summary>
        /// <returns><c>true</c> - если обновление прошло успешно</returns>
        bool RefreshToken();
        /// <summary>
        /// Установить значение токена
        /// </summary>
        /// <param name="token">Токен</param>
        void SetToken(string token);
    }
}