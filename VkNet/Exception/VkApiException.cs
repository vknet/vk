namespace VkNet.Exception
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Базовый класс для всех исключений, выбрасываемых библиотекой.
    /// </summary>
    [Serializable]
    public class VkApiException : Exception
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="VkApiException"/>.
        /// </summary>
        public VkApiException()
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="VkApiException"/> с указанным описанием.
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        public VkApiException(string message) : base(message)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="InvalidParameterException"/> с указанным описанием и внутренним исключением.
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="innerException">Внутреннее исключение.</param>
        public VkApiException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="VkApiException"/> на основе ранее сериализованных данных.
        /// </summary>
        /// <param name="info">Содержит все данные, необходимые для десериализации.</param>
        /// <param name="context">Описывает источник и назначение данного сериализованного потока и предоставляет дополнительный, 
        /// определяемый вызывающим, контекст.</param>
        protected VkApiException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}