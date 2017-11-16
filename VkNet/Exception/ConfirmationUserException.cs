using System.Runtime.Serialization;
using VkNet.Utils;

namespace VkNet.Exception
{
    /// <summary>
    /// Исключение, которое выбрасывается, если требуется подтверждение со стороны пользователя.
	/// Код ошибки - 24
	/// </summary>
    [DataContract]
    public class ConfirmationUserException : VkApiMethodInvokeException
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса ConfirmationUserException
        /// </summary>
        public ConfirmationUserException()
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса ConfirmationUserException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        public ConfirmationUserException(string message) : base(message)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса ConfirmationUserException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="innerException">Внутреннее исключение.</param>
        public ConfirmationUserException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса ConfirmationUserException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="code">Код ошибки, полученный от сервера ВКонтакте.</param>
        public ConfirmationUserException(string message, int code) : base(message, code)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса VkApiException
        /// </summary>
        /// <param name="response">Ответ от сервера vk</param>
        public ConfirmationUserException(VkResponse response) : base(response["error_msg"])
        {
            ErrorCode = response["error_code"];
        }
    }
}