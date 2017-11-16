using System.Runtime.Serialization;
using VkNet.Utils;

namespace VkNet.Exception
{
    /// <summary>
    /// Исключение, которое выбрасывается при внутренней ошибке сервера.
	/// Попробуйте повторить запрос позже.
	/// Код ошибки - 10
	/// </summary>
    [DataContract]
    public class PublicServerErrorException : VkApiMethodInvokeException
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса PublicServerErrorException
        /// </summary>
        public PublicServerErrorException()
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса PublicServerErrorException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        public PublicServerErrorException(string message) : base(message)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса PublicServerErrorException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="innerException">Внутреннее исключение.</param>
        public PublicServerErrorException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса PublicServerErrorException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="code">Код ошибки, полученный от сервера ВКонтакте.</param>
        public PublicServerErrorException(string message, int code) : base(message, code)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса VkApiException
        /// </summary>
        /// <param name="response">Ответ от сервера vk</param>
        public PublicServerErrorException(VkResponse response) : base(response["error_msg"])
        {
            ErrorCode = response["error_code"];
        }
    }
}