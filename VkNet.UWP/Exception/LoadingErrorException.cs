using System.Runtime.Serialization;
using VkNet.Utils;

namespace VkNet.Exception
{
    /// <summary>
    /// Исключение, которое выбрасывается при ошибке загрузки документа.
	/// Код ошибки - 22
	/// </summary>
    [DataContract]
    public class LoadingErrorException : VkApiMethodInvokeException
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса LoadingErrorException
        /// </summary>
        public LoadingErrorException()
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса LoadingErrorException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        public LoadingErrorException(string message) : base(message)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса LoadingErrorException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="innerException">Внутреннее исключение.</param>
        public LoadingErrorException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса LoadingErrorException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="code">Код ошибки, полученный от сервера ВКонтакте.</param>
        public LoadingErrorException(string message, int code) : base(message, code)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса VkApiException
        /// </summary>
        /// <param name="response">Ответ от сервера vk</param>
        public LoadingErrorException(VkResponse response) : base(response["error_msg"])
        {
            ErrorCode = response["error_code"];
        }
    }
}