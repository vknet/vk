using System;
using VkNet.Utils;

namespace VkNet.Exception
{
    /// <summary>
    /// Исключение, которое выбрасывается при превышении лимита комментариев на стене.
	/// Код ошибки - 223
	/// </summary>
    [Serializable]
    public class TooManyAdsPostsException : VkApiMethodInvokeException
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса CommentsLimitReachedException
        /// </summary>
        public TooManyAdsPostsException()
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса CommentsLimitReachedException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        public TooManyAdsPostsException(string message) : base(message)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса CommentsLimitReachedException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="innerException">Внутреннее исключение.</param>
        public TooManyAdsPostsException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса CommentsLimitReachedException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="code">Код ошибки, полученный от сервера ВКонтакте.</param>
        public TooManyAdsPostsException(string message, int code) : base(message, code)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса VkApiException
        /// </summary>
        /// <param name="response">Ответ от сервера vk</param>
        public TooManyAdsPostsException(VkResponse response) : base(response["error_msg"])
        {
            ErrorCode = response["error_code"];
        }
    }
}