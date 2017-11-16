using System.Runtime.Serialization;
using VkNet.Utils;

namespace VkNet.Exception
{
    /// <summary>
    /// Исключение, которое выбрасывается, если доступ к группе запрещен.
	/// Убедитесь, что текущий пользователь является участником или руководителем сообщества (для закрытых и частных групп и встреч).
	/// Код ошибки - 203
	/// </summary>
    [DataContract]
    public class GroupAccessDeniedException : VkApiMethodInvokeException
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса GroupAccessDeniedException
        /// </summary>
        public GroupAccessDeniedException()
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса GroupAccessDeniedException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        public GroupAccessDeniedException(string message) : base(message)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса GroupAccessDeniedException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="innerException">Внутреннее исключение.</param>
        public GroupAccessDeniedException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса GroupAccessDeniedException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="code">Код ошибки, полученный от сервера ВКонтакте.</param>
        public GroupAccessDeniedException(string message, int code) : base(message, code)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса VkApiException
        /// </summary>
        /// <param name="response">Ответ от сервера vk</param>
        public GroupAccessDeniedException(VkResponse response) : base(response["error_msg"])
        {
            ErrorCode = response["error_code"];
        }
    }
}