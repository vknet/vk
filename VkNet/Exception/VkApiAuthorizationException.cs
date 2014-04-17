using VkNet.Enums.Filters;

namespace VkNet.Exception
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Исключение, которое выбрасывается при попытке неудачной авторизации, когда указан неправильный логин или пароль 
    /// при вызове метода <see cref="VkApi.Authorize(int,string,string,Settings)"/>.
    /// </summary>
    [Serializable]
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
        /// Инициализирует новый экземпляр класса <see cref="VkApiAuthorizationException"/>.
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="email">Логин, который был указан при попытке авторизации.</param>
        /// <param name="password">Пароль, который был указан при попытке авторизации.</param>
        public VkApiAuthorizationException(string message, string email, string password) : base(message)
        {
            Email = email;
            Password = password;
        }


        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="AccessTokenInvalidException"/> на основе ранее сериализованных данных.
        /// </summary>
        /// <param name="info">Содержит все данные, необходимые для десериализации.</param>
        /// <param name="context">Описывает источник и назначение данного сериализованного потока и предоставляет дополнительный, 
        /// определяемый вызывающим, контекст.</param>
        protected VkApiAuthorizationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}