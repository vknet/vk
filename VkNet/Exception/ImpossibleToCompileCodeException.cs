using System;
using VkNet.Utils;

namespace VkNet.Exception
{    
    /// <summary>
    /// Исключение, которое выбрасывается, если невозможно скомпилировать код.
    /// Код ошибки - 12
    /// </summary>
    [Serializable]
    public class ImpossibleToCompileCodeException : VkApiMethodInvokeException
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса ImpossibleToCompileTheCode
        /// </summary>
        public ImpossibleToCompileCodeException()
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса ImpossibleToCompileTheCode
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        public ImpossibleToCompileCodeException(string message) : base(message)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса ImpossibleToCompileTheCode
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="innerException">Внутреннее исключение.</param>
        public ImpossibleToCompileCodeException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса ImpossibleToCompileTheCode
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="code">Код ошибки, полученный от сервера ВКонтакте.</param>
        public ImpossibleToCompileCodeException(string message, int code) : base(message, code)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса VkApiException
        /// </summary>
        /// <param name="response">Ответ от сервера vk</param>
        public ImpossibleToCompileCodeException(VkResponse response) : base(response["error_msg"])
        {
            ErrorCode = response["error_code"];
        }
    }
}
