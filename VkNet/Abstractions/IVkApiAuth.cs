namespace VkNet.Abstractions
{
    /// <summary>
    /// VkApi Authorization
    /// </summary>
    public interface IVkApiAuth
    {
        /// <summary>
        /// Была ли произведена авторизация каким либо образом
        /// </summary>
        bool IsAuthorized { get; }

        /// <summary>
        /// Авторизация и получение токена
        /// </summary>
        /// <param name="params">Данные авторизации</param>
        void Authorize(IApiAuthParams @params);
    }
}