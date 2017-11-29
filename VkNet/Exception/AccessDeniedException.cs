using VkNet.Utils;

namespace VkNet.Exception
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Исключение, которое выбрасывается при отказе в доступе на выполнение операции сервером ВКонтакте.
    /// Код ошибки - 500
	/// </summary>
    [Serializable]
    public class AccessDeniedException : VkApiMethodInvokeException
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса AccessDeniedException
        /// </summary>
        public AccessDeniedException()
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса AccessDeniedException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        public AccessDeniedException(string message) : base(message)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса AccessDeniedException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="innerException">Внутреннее исключение.</param>
        public AccessDeniedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса AccessDeniedException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="code">Код ошибки, полученный от сервера ВКонтакте.</param>
        public AccessDeniedException(string message, int code) : base(message, code)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса AccessDeniedException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="code">Код ошибки, полученный от сервера ВКонтакте.</param>
        /// <param name="innerException">Внутреннее исключение.</param>
        public AccessDeniedException(string message, int code, Exception innerException) : base(message, code, innerException)
        {
        }

		/// <summary>
		/// Инициализирует новый экземпляр класса AccessDeniedException
		/// </summary>
		/// <param name="response">Ответ от сервера vk</param>
		public AccessDeniedException(VkResponse response) : base(response["error_msg"])
		{
			ErrorCode = response["error_code"];
		}
	}
}