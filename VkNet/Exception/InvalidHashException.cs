using System;

using VkNet.Utils;

namespace VkNet.Exception
{
    /// <summary>
    /// Исключение, которое выбрасывается при неверном хэше.
	/// Код ошибки - 121
	/// </summary>
    [Serializable]
    public class InvalidHashException : VkApiMethodInvokeException
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса InvalidHashException
        /// </summary>
        public InvalidHashException()
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса InvalidHashException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        public InvalidHashException(string message) : base(message)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса InvalidHashException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="innerException">Внутреннее исключение.</param>
        public InvalidHashException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса InvalidHashException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="code">Код ошибки, полученный от сервера ВКонтакте.</param>
        public InvalidHashException(string message, int code) : base(message, code)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса VkApiException
        /// </summary>
        /// <param name="response">Ответ от сервера vk</param>
        public InvalidHashException(VkResponse response) : base(response["error_msg"])
        {
            ErrorCode = response["error_code"];
        }
    }
}