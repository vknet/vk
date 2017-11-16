using System.Runtime.Serialization;
using VkNet.Utils;

namespace VkNet.Exception
{
    /// <summary>
    /// Исключение, которое выбрасывается при остутствии доступа к пользователю.
    /// Доступ к пользователю запрещен.
	/// Код ошибки - 170
	/// </summary>
    [DataContract]
    public class UserAccessDeniedException : VkApiMethodInvokeException
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса UserAccessDeniedException
        /// </summary>
        public UserAccessDeniedException()
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса UserAccessDeniedException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        public UserAccessDeniedException(string message) : base(message)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса UserAccessDeniedException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="innerException">Внутреннее исключение.</param>
        public UserAccessDeniedException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса UserAccessDeniedException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="code">Код ошибки, полученный от сервера ВКонтакте.</param>
        public UserAccessDeniedException(string message, int code) : base(message, code)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса VkApiException
        /// </summary>
        /// <param name="response">Ответ от сервера vk</param>
        public UserAccessDeniedException(VkResponse response) : base(response["error_msg"])
        {
            ErrorCode = response["error_code"];
        }
    }
}