using System.Runtime.Serialization;
using VkNet.Utils;

namespace VkNet.Exception
{
    /// <summary>
    /// Исключение, которые выбрасывается при попытке добавить в друзья пользователя, который занес Вас в свой черный список.
	/// Код ошибки - 175
    /// </summary>
    [DataContract]
    public class CannotAddYouBlacklistedException : VkApiMethodInvokeException
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса CannotAddYouBlacklistedException
        /// </summary>
        public CannotAddYouBlacklistedException()
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса CannotAddYouBlacklistedException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        public CannotAddYouBlacklistedException(string message) : base(message)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса CannotAddYouBlacklistedException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="innerException">Внутреннее исключение.</param>
        public CannotAddYouBlacklistedException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса CannotAddYouBlacklistedException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="code">Код ошибки, полученный от сервера ВКонтакте.</param>
        public CannotAddYouBlacklistedException(string message, int code) : base(message, code)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса VkApiException
        /// </summary>
        /// <param name="response">Ответ от сервера vk</param>
        public CannotAddYouBlacklistedException(VkResponse response) : base(response["error_msg"])
        {
            ErrorCode = response["error_code"];
        }
    }
}