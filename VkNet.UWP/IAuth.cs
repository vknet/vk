namespace VkNet
{
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
    }
}