using System.Runtime.Serialization;
using VkNet.Utils;

namespace VkNet.Exception
{
    /// <summary>
    /// Исключение, которое выбрасывается при попытке запроса, когда приложение выключено (appid)
	/// Необходимо включить приложение в настройках https://vk.com/editapp?id={Ваш API_ID} или использовать тестовый режим (test_mode=1)
	/// Код ошибки - 2
	/// </summary>
    [DataContract]
    public class AppOffException : VkApiMethodInvokeException
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса AppOffException
        /// </summary>
        public AppOffException()
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса AppOffException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        public AppOffException(string message) : base(message)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса AppOffException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="innerException">Внутреннее исключение.</param>
        public AppOffException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса AppOffException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="code">Код ошибки, полученный от сервера ВКонтакте.</param>
        public AppOffException(string message, int code) : base(message, code)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса VkApiException
        /// </summary>
        /// <param name="response">Ответ от сервера vk</param>
        public AppOffException(VkResponse response) : base(response["error_msg"])
        {
            ErrorCode = response["error_code"];
        }
    }
}