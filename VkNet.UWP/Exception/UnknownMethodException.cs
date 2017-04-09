using System.Runtime.Serialization;
using VkNet.Utils;

namespace VkNet.Exception
{
    /// <summary>
    /// Исключение, которое выбрасывается при передаче неизвестного метода
	/// Проверьте, правильно ли указано название вызываемого метода: http://vk.com/dev/methods.
	/// Код ошибки - 3
	/// </summary>
    [DataContract]
    public class UnknownMethodException : VkApiMethodInvokeException
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса UnknownMethodException
        /// </summary>
        public UnknownMethodException()
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса UnknownMethodException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        public UnknownMethodException(string message) : base(message)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса UnknownMethodException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="innerException">Внутреннее исключение.</param>
        public UnknownMethodException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса UnknownMethodException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="code">Код ошибки, полученный от сервера ВКонтакте.</param>
        public UnknownMethodException(string message, int code) : base(message, code)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса VkApiException
        /// </summary>
        /// <param name="response">Ответ от сервера vk</param>
        public UnknownMethodException(VkResponse response) : base(response["error_msg"])
        {
            ErrorCode = response["error_code"];
        }
    }
}