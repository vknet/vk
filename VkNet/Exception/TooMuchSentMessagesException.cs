using VkNet.Utils;

namespace VkNet.Exception
{
    /// <summary>
    /// 
    /// </summary>
    public class TooMuchSentMessagesException: VkApiMethodInvokeException
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса TooMuchSentMessagesException
        /// </summary>
        public TooMuchSentMessagesException()
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса TooMuchSentMessagesException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        public TooMuchSentMessagesException(string message) : base(message)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса TooMuchSentMessagesException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="innerException">Внутреннее исключение.</param>
        public TooMuchSentMessagesException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса TooMuchSentMessagesException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="code">Код ошибки, полученный от сервера ВКонтакте.</param>
        public TooMuchSentMessagesException(string message, int code) : base(message, code)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса VkApiException
        /// </summary>
        /// <param name="response">Ответ от сервера vk</param>
        public TooMuchSentMessagesException(VkResponse response) : base(response["error_msg"])
        {
            ErrorCode = response["error_code"];
        }
    }
}