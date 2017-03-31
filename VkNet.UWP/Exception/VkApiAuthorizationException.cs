namespace VkNet.Exception
{
    using System.Runtime.Serialization;

    using Enums.Filters;

    /// <summary>
    /// Исключение, которое выбрасывается при попытке неудачной авторизации, когда указан неправильный логин или пароль
    /// при вызове метода VkApi.Authorize
    /// </summary>
    [DataContract]
    public class VkApiAuthorizationException : VkApiException
    {
        /// <summary>
        /// Логин, который был указан при попытке авторизации.
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// Пароль, который был указан при попытке авторизации.
        /// </summary>
        public string Password { get; private set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса VkApiAuthorizationException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="email">Логин, который был указан при попытке авторизации.</param>
        /// <param name="password">Пароль, который был указан при попытке авторизации.</param>
        public VkApiAuthorizationException(string message, string email, string password) : base(message)
        {
            Email = email;
            Password = password;
        }
    }
}