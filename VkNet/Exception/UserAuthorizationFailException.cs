namespace VkNet.Exception
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Исключение, которое выбрасывается при отсутствии авторизации на выполнение запрошенной операции.
    /// </summary>
    [Serializable]
    public class UserAuthorizationFailException : VkApiMethodInvokeException
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="UserAuthorizationFailException"/>.
        /// </summary>
        public UserAuthorizationFailException(string message) : base(message)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="UserAuthorizationFailException"/> с указанным описанием и кодом ошибки.
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="code">Код ошибки, полученный от сервера ВКонтакте.</param>
        public UserAuthorizationFailException(string message, int code) : base(message, code)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="UserAuthorizationFailException"/> на основе ранее сериализованных данных.
        /// </summary>
        /// <param name="info">Содержит все данные, необходимые для десериализации.</param>
        /// <param name="context">Описывает источник и назначение данного сериализованного потока и предоставляет дополнительный, 
        /// определяемый вызывающим, контекст.</param>
        protected UserAuthorizationFailException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}