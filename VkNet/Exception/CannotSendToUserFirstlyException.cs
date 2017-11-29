using System;
using System.Runtime.Serialization;
using VkNet.Utils;

namespace VkNet.Exception
{
    /// <summary>
    /// Исключение, которое выбрасывается при попытке первым написать пользователю от имени группы.
	/// Код ошибки - 901
	/// </summary>
    [Serializable]
    public class CannotSendToUserFirstlyException : VkApiMethodInvokeException
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса CannotSendToUserFirstlyException
        /// </summary>
        public CannotSendToUserFirstlyException()
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса CannotSendToUserFirstlyException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        public CannotSendToUserFirstlyException(string message) : base(message)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса CannotSendToUserFirstlyException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="innerException">Внутреннее исключение.</param>
        public CannotSendToUserFirstlyException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса CannotSendToUserFirstlyException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="code">Код ошибки, полученный от сервера ВКонтакте.</param>
        public CannotSendToUserFirstlyException(string message, int code) : base(message, code)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса VkApiException
        /// </summary>
        /// <param name="response">Ответ от сервера vk</param>
        public CannotSendToUserFirstlyException(VkResponse response) : base(response["error_msg"])
        {
            ErrorCode = response["error_code"];
        }
    }
}