namespace VkNet.Exception
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Базовый класс для всех исключений, выбрасываемых библиотекой.
    /// </summary>
    [DataContract]
    public class VkApiException : Exception
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса VkApiException
        /// </summary>
        public VkApiException()
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса VkApiException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        public VkApiException(string message) : base(message)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса InvalidParameterException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="innerException">Внутреннее исключение.</param>
        public VkApiException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}