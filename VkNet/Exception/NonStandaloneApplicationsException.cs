using System;
using System.Runtime.Serialization;
using VkNet.Utils;

namespace VkNet.Exception
{
    /// <summary>
    /// Исключение, которое выбрасывается, если действие запрещено для не Standalone приложений.
	/// Если ошибка возникает несмотря на то, что Ваше приложение имеет тип Standalone, убедитесь, что при авторизации Вы используете redirect_uri=https://oauth.vk.com/blank.html. Подробнее см. http://vk.com/dev/auth_mobile.
	/// Код ошибки - 20
	/// </summary>
    [Serializable]
    public class NonStandaloneApplicationsException : VkApiMethodInvokeException
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса NonStandaloneApplicationsException
        /// </summary>
        public NonStandaloneApplicationsException()
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса NonStandaloneApplicationsException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        public NonStandaloneApplicationsException(string message) : base(message)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса NonStandaloneApplicationsException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="innerException">Внутреннее исключение.</param>
        public NonStandaloneApplicationsException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса NonStandaloneApplicationsException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="code">Код ошибки, полученный от сервера ВКонтакте.</param>
        public NonStandaloneApplicationsException(string message, int code) : base(message, code)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса VkApiException
        /// </summary>
        /// <param name="response">Ответ от сервера vk</param>
        public NonStandaloneApplicationsException(VkResponse response) : base(response["error_msg"])
        {
            ErrorCode = response["error_code"];
        }
    }
}