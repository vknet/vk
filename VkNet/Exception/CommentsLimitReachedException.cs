using System.Runtime.Serialization;
using VkNet.Utils;

namespace VkNet.Exception
{
    /// <summary>
    /// Исключение, которое выбрасывается при превышении лимита комментариев на стене.
	/// Код ошибки - 223
	/// </summary>
    [DataContract]
    public class CommentsLimitReachedException : VkApiMethodInvokeException
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса CommentsLimitReachedException
        /// </summary>
        public CommentsLimitReachedException()
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса CommentsLimitReachedException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        public CommentsLimitReachedException(string message) : base(message)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса CommentsLimitReachedException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="innerException">Внутреннее исключение.</param>
        public CommentsLimitReachedException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса CommentsLimitReachedException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="code">Код ошибки, полученный от сервера ВКонтакте.</param>
        public CommentsLimitReachedException(string message, int code) : base(message, code)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса VkApiException
        /// </summary>
        /// <param name="response">Ответ от сервера vk</param>
        public CommentsLimitReachedException(VkResponse response) : base(response["error_msg"])
        {
            ErrorCode = response["error_code"];
        }
    }
}