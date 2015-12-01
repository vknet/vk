namespace VkNet.Exception
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Исключение, которое выбрасывается, в случае, если предоставленный маркер доступа является недействительным.
    /// </summary>
    [Serializable]
    public class AccessTokenInvalidException : VkApiException
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="AccessTokenInvalidException"/>.
        /// </summary>
        public AccessTokenInvalidException()
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="AccessTokenInvalidException"/> с указанным описанием.
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        public AccessTokenInvalidException(string message) : base(message)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="AccessTokenInvalidException"/> с указанным описанием и внутренним исключением.
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="innerException">Внутреннее исключение.</param>
        public AccessTokenInvalidException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="AccessTokenInvalidException"/> на основе ранее сериализованных данных.
        /// </summary>
        /// <param name="info">Содержит все данные, необходимые для десериализации.</param>
        /// <param name="context">Описывает источник и назначение данного сериализованного потока и предоставляет дополнительный,
        /// определяемый вызывающим, контекст.</param>
        protected AccessTokenInvalidException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}