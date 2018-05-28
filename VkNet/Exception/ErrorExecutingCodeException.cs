using System;
using VkNet.Utils;

namespace VkNet.Exception
{
    /// <summary>
    /// Исключение, которое выбрасывается, если произошла ошибка выполнения кода.
    /// Код ошибки - 13
    /// </summary>
    [Serializable]
    public class ErrorExecutingCodeException : VkApiMethodInvokeException
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса ErrorExecutingCodeException
        /// </summary>
        public ErrorExecutingCodeException()
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса ErrorExecutingCodeException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        public ErrorExecutingCodeException(string message) : base(message)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса ErrorExecutingCodeException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="innerException">Внутреннее исключение.</param>
        public ErrorExecutingCodeException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса ErrorExecutingCodeException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="code">Код ошибки, полученный от сервера ВКонтакте.</param>
        public ErrorExecutingCodeException(string message, int code) : base(message, code)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса VkApiException
        /// </summary>
        /// <param name="response">Ответ от сервера vk</param>
        public ErrorExecutingCodeException(VkResponse response) : base(response["error_msg"])
        {
            ErrorCode = response["error_code"];
        }
    }
}
