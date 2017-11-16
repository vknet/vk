using System.Runtime.Serialization;
using VkNet.Utils;

namespace VkNet.Exception
{
    /// <summary>
    /// Исключение, которое выбрасывается, если нет прав на выполнение операций с рекламным кабинетом.
	/// Код ошибки - 600
	/// </summary>
    [DataContract]
    public class AdsAccessDeniedException : VkApiMethodInvokeException
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса AdsAccessDeniedException
        /// </summary>
        public AdsAccessDeniedException()
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса AdsAccessDeniedException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        public AdsAccessDeniedException(string message) : base(message)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса AdsAccessDeniedException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="innerException">Внутреннее исключение.</param>
        public AdsAccessDeniedException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса AdsAccessDeniedException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="code">Код ошибки, полученный от сервера ВКонтакте.</param>
        public AdsAccessDeniedException(string message, int code) : base(message, code)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса VkApiException
        /// </summary>
        /// <param name="response">Ответ от сервера vk</param>
        public AdsAccessDeniedException(VkResponse response) : base(response["error_msg"])
        {
            ErrorCode = response["error_code"];
        }
    }
}