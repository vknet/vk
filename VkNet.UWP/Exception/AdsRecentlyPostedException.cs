using System.Runtime.Serialization;
using VkNet.Utils;

namespace VkNet.Exception
{
    /// <summary>
    /// Исключение, которое выбрасывается, если рекламный пост уже недавно публиковался.
	/// Код ошибки - 219
	/// </summary>
    [DataContract]
    public class AdsRecentlyPostedException : VkApiMethodInvokeException
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса AdsRecentlyPostedException
        /// </summary>
        public AdsRecentlyPostedException()
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса AdsRecentlyPostedException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        public AdsRecentlyPostedException(string message) : base(message)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса AdsRecentlyPostedException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="innerException">Внутреннее исключение.</param>
        public AdsRecentlyPostedException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса AdsRecentlyPostedException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="code">Код ошибки, полученный от сервера ВКонтакте.</param>
        public AdsRecentlyPostedException(string message, int code) : base(message, code)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса VkApiException
        /// </summary>
        /// <param name="response">Ответ от сервера vk</param>
        public AdsRecentlyPostedException(VkResponse response) : base(response["error_msg"])
        {
            ErrorCode = response["error_code"];
        }
    }
}