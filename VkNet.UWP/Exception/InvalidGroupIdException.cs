using System.Runtime.Serialization;
using VkNet.Utils;

namespace VkNet.Exception
{
    /// <summary>
    /// Исключение, которое выбрасывается, если идентификатор сообщества неверен.
	/// Код ошибки - 125
	/// </summary>
    [DataContract]
    public class InvalidGroupIdException : VkApiMethodInvokeException
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса InvalidGroupIdException
        /// </summary>
        public InvalidGroupIdException()
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса InvalidGroupIdException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        public InvalidGroupIdException(string message) : base(message)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса InvalidGroupIdException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="innerException">Внутреннее исключение.</param>
        public InvalidGroupIdException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса InvalidGroupIdException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="code">Код ошибки, полученный от сервера ВКонтакте.</param>
        public InvalidGroupIdException(string message, int code) : base(message, code)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса VkApiException
        /// </summary>
        /// <param name="response">Ответ от сервера vk</param>
        public InvalidGroupIdException(VkResponse response) : base(response["error_msg"])
        {
            ErrorCode = response["error_code"];
        }
    }
}