using System.Runtime.Serialization;
using VkNet.Utils;

namespace VkNet.Exception
{
    /// <summary>
    /// Исключение, которое выбрасывается при неверном запросе.
	/// Проверьте синтаксис запроса и список используемых параметров (его можно найти на странице с описанием метода).   
	/// Код ошибки - 8
	/// </summary>
    [DataContract]
    public class InvalidRequestException : VkApiMethodInvokeException
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса InvalidRequestException
        /// </summary>
        public InvalidRequestException()
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса InvalidRequestException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        public InvalidRequestException(string message) : base(message)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса InvalidRequestException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="innerException">Внутреннее исключение.</param>
        public InvalidRequestException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса InvalidRequestException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="code">Код ошибки, полученный от сервера ВКонтакте.</param>
        public InvalidRequestException(string message, int code) : base(message, code)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса VkApiException
        /// </summary>
        /// <param name="response">Ответ от сервера vk</param>
        public InvalidRequestException(VkResponse response) : base(response["error_msg"])
        {
            ErrorCode = response["error_code"];
        }
    }
}