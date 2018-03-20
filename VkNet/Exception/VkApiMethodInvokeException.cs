namespace VkNet.Exception
{
    using System;
    

    /// <summary>
    /// Базовый класс, для всех исключений, которые могут произойти при вызове методов API ВКонтакте.
    /// </summary>
    [Serializable]
    public class VkApiMethodInvokeException : VkApiException
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса VkApiMethodInvokeException
        /// </summary>
        public VkApiMethodInvokeException()
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса VkApiMethodInvokeException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        public VkApiMethodInvokeException(string message) : base(message)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса VkApiMethodInvokeException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="innerException">Внутреннее исключение.</param>
        public VkApiMethodInvokeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса VkApiMethodInvokeException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="code">Код ошибки, полученный от сервера ВКонтакте.</param>
        public VkApiMethodInvokeException(string message, int code) : base(message)
        {
            ErrorCode = code;
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса VkApiMethodInvokeException
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