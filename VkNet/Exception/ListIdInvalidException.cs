using System;
using System.Runtime.Serialization;
using VkNet.Utils;

namespace VkNet.Exception
{
    /// <summary>
    /// Исключение, которое выбрасывается, если идентификатор списка неверен.
	/// Код ошибки - 171
	/// </summary>
    [Serializable]
    public class ListIdInvalidException : VkApiMethodInvokeException
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса ListIdInvalidException
        /// </summary>
        public ListIdInvalidException()
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса ListIdInvalidException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        public ListIdInvalidException(string message) : base(message)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса ListIdInvalidException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="innerException">Внутреннее исключение.</param>
        public ListIdInvalidException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса ListIdInvalidException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="code">Код ошибки, полученный от сервера ВКонтакте.</param>
        public ListIdInvalidException(string message, int code) : base(message, code)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса VkApiException
        /// </summary>
        /// <param name="response">Ответ от сервера vk</param>
        public ListIdInvalidException(VkResponse response) : base(response["error_msg"])
        {
            ErrorCode = response["error_code"];
        }
    }
}