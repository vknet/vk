using System.Runtime.Serialization;
using VkNet.Utils;

namespace VkNet.Exception
{
    /// <summary>
    /// Исключение, которое выбрасывается, если доступ к комментированию записи запрещен.
	/// Код ошибки - 213
	/// </summary>
    [DataContract]
    public class AccessToCommentDeniedException : VkApiMethodInvokeException
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса AccessToCommentDeniedException
        /// </summary>
        public AccessToCommentDeniedException()
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса AccessToCommentDeniedException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        public AccessToCommentDeniedException(string message) : base(message)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса AccessToCommentDeniedException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="innerException">Внутреннее исключение.</param>
        public AccessToCommentDeniedException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса AccessToCommentDeniedException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="code">Код ошибки, полученный от сервера ВКонтакте.</param>
        public AccessToCommentDeniedException(string message, int code) : base(message, code)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса VkApiException
        /// </summary>
        /// <param name="response">Ответ от сервера vk</param>
        public AccessToCommentDeniedException(VkResponse response) : base(response["error_msg"])
        {
            ErrorCode = response["error_code"];
        }
    }
}