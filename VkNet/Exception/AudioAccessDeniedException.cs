using System.Runtime.Serialization;
using VkNet.Utils;

namespace VkNet.Exception
{
    /// <summary>
    /// Исключение, которое выбрасывается, если доступ к аудио запрещен.
	/// Убедитесь, что Вы используете верные идентификаторы (для пользователей owner_id положительный, для сообществ — отрицательный), и доступ к запрашиваемому контенту для текущего пользователя есть в полной версии сайта.
	/// Код ошибки - 201
	/// </summary>
    [DataContract]
    public class AudioAccessDeniedException : VkApiMethodInvokeException
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса AudioAccessDeniedException
        /// </summary>
        public AudioAccessDeniedException()
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса AudioAccessDeniedException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        public AudioAccessDeniedException(string message) : base(message)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса AudioAccessDeniedException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="innerException">Внутреннее исключение.</param>
        public AudioAccessDeniedException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса AudioAccessDeniedException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="code">Код ошибки, полученный от сервера ВКонтакте.</param>
        public AudioAccessDeniedException(string message, int code) : base(message, code)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса VkApiException
        /// </summary>
        /// <param name="response">Ответ от сервера vk</param>
        public AudioAccessDeniedException(VkResponse response) : base(response["error_msg"])
        {
            ErrorCode = response["error_code"];
        }
    }
}