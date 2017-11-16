using System.Runtime.Serialization;
using VkNet.Utils;

namespace VkNet.Exception
{
    /// <summary>
    /// Исключение, которое выбрасывается, если один из необходимых параметров был не передан или неверен.
	/// Проверьте список требуемых параметров и их формат на странице с описанием метода.      
	/// Код ошибки - 100
	/// </summary>
    [DataContract]
    public class ParameterMissingOrInvalidException : VkApiMethodInvokeException
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса ParameterMissingOrInvalidException
        /// </summary>
        public ParameterMissingOrInvalidException()
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса ParameterMissingOrInvalidException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        public ParameterMissingOrInvalidException(string message) : base(message)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса ParameterMissingOrInvalidException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="innerException">Внутреннее исключение.</param>
        public ParameterMissingOrInvalidException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса ParameterMissingOrInvalidException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="code">Код ошибки, полученный от сервера ВКонтакте.</param>
        public ParameterMissingOrInvalidException(string message, int code) : base(message, code)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса VkApiException
        /// </summary>
        /// <param name="response">Ответ от сервера vk</param>
        public ParameterMissingOrInvalidException(VkResponse response) : base(response["error_msg"])
        {
            ErrorCode = response["error_code"];
        }
    }
}