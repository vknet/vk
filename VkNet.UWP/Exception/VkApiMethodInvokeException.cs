namespace VkNet.Exception
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Базовый класс, для всех исключений, которые могут произойти при вызове методов API ВКонтакте.
    /// </summary>
    [DataContract]
    public class VkApiMethodInvokeException : VkApiException
    {
        /// <summary>
        /// Код ошибки, полученный от сервера ВКонтакте.
        /// </summary>
        public int ErrorCode { get; private set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="VkApiMethodInvokeException"/>.
        /// </summary>
        public VkApiMethodInvokeException()
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="VkApiMethodInvokeException"/> с указанным описанием.
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        public VkApiMethodInvokeException(string message) : base(message)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="VkApiMethodInvokeException"/> с указанным описанием и внутренним исключением.
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="innerException">Внутреннее исключение.</param>
        public VkApiMethodInvokeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="VkApiMethodInvokeException"/> с указанным описанием и кодом ошибки.
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="code">Код ошибки, полученный от сервера ВКонтакте.</param>
        public VkApiMethodInvokeException(string message, int code) : base(message)
        {
            ErrorCode = code;
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="VkApiMethodInvokeException"/> с указанным описанием, кодом ошибки и внутренним исключением.
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="code">Код ошибки, полученный от сервера ВКонтакте.</param>
        /// <param name="innerException">Внутреннее исключение.</param>
        public VkApiMethodInvokeException(string message, int code, Exception innerException) : base(message, innerException)
        {
            ErrorCode = code;
        }
    }
}