using System;
using System.Runtime.Serialization;
using VkNet.Utils;

namespace VkNet.Exception
{
    /// <summary>
    /// Исключение, которое выбрасывается, если требуется выполнение запросов по HTTPS
	/// Требуется выполнение запросов по протоколу HTTPS, т.к. пользователь включил настройку, требующую работу через безопасное соединение.
    /// Чтобы избежать появления такой ошибки, в Standalone-приложении Вы можете предварительно проверять состояние этой настройки у пользователя методом account.getInfo.  
	/// Код ошибки - 16
	/// </summary>
    [Serializable]
    public class NeedHttpsException : VkApiMethodInvokeException
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса NeedHttpsException
        /// </summary>
        public NeedHttpsException()
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса NeedHttpsException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        public NeedHttpsException(string message) : base(message)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса NeedHttpsException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="innerException">Внутреннее исключение.</param>
        public NeedHttpsException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса NeedHttpsException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="code">Код ошибки, полученный от сервера ВКонтакте.</param>
        public NeedHttpsException(string message, int code) : base(message, code)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса VkApiException
        /// </summary>
        /// <param name="response">Ответ от сервера vk</param>
        public NeedHttpsException(VkResponse response) : base(response["error_msg"])
        {
            ErrorCode = response["error_code"];
        }
    }
}